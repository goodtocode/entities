using GoodToCode.Occurrences.Infrastructure;
using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventAggregateSteps
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;
        private Guid SutKey { get; set; }
        private Event Sut { get; set; }

        public EventAggregateSteps()
        {
            _config = new ConfigurationFactory("Occurrences.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Event is created for the aggregate")]
        public void GivenANewEventIsCreatedForTheAggregate()
        {
            SutKey = Guid.NewGuid();
            Sut = new Event()
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
            var aggregate = new EventAggregate(_dbContext);
            _rowsAffected = await aggregate.EventSaveAsync(Sut);
            SutKey = Sut.EventKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the aggregate inserted Event can be queried by key")]
        public async Task ThenTheAggregateInsertedEventCanBeQueriedByKey()
        {
            var found = await _dbContext.Event.Where(x => x.EventKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }
    }
}
