using GoodToCode.Occurrences.Infrastructure;
using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventAggregateSteps : IAggregateSteps<EventAggregate>
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;

        public Guid SutKey { get; private set; }
        public EventAggregate Aggregate { get; private set; }
        public IList<EventAggregate> RecycleBin { get; private set; }

        public Event SutEvent { get; private set; }

        public EventAggregateSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
            Aggregate = new EventAggregate(_dbContext);
        }

        [Given(@"A new Event is created for the aggregate")]
        public void GivenANewEventIsCreatedForTheAggregate()
        {
            SutKey = Guid.Empty;
            SutEvent = new Event()
            {
                EventKey = SutKey,
                EventName = "EventAggregateSteps.cs Test"
            };
        }

        [When(@"the Event does not exist in persistence")]
        public async Task WhenTheEventDoesNotExistInPersistence()
        {
            var found = await _dbContext.Event.Where(x => x.EventKey == SutKey).AnyAsync();
            Assert.IsFalse(found);
        }

        [When(@"the Event is saved via the aggregate")]
        public async Task WhenTheEventIsSavedViaTheAggregate()
        {
            _rowsAffected = await Aggregate.EventSaveAsync(SutEvent);
            SutKey = SutEvent.EventKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the aggregate inserted Event can be queried by key")]
        public async Task ThenTheAggregateInsertedEventCanBeQueriedByKey()
        {
            var found = await _dbContext.Event.Where(x => x.EventKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await Aggregate.EventDeleteAsync(SutEvent);
        }
    }
}
