using GoodToCode.Occurrences.Application;
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
    public class EventSaveCommandSteps : ICommandSteps<Event>
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        public Guid SutKey { get; private set; }
        public Event Sut { get; private set; }
        public IList<Event> RecycleBin { get; private set; }

        public EventSaveCommandSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Event Save Command has been created")]
        public void GivenANewEventSaveCommandHasBeenCreated()
        {
            SutKey = Guid.Empty;
            Sut = new Event()
            {
                EventKey = SutKey,
                EventName = "EventSaveCommandSteps.cs Test"
            };
        }

        [Given(@"the Event Save Command validates")]
        public void GivenTheEventSaveCommandValidates()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(Sut.EventName));
        }

        [When(@"the Event is inserted via CQRS Command")]
        public async Task WhenTheEventIsInsertedViaCQRSCommand()
        {
            var query = new EventSaveCommand(Sut);
            var handle = new EventSaveHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            SutKey = response.Result.EventKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [Then(@"the CQRS inserted Event can be queried by key")]
        public async Task ThenTheCQRSInsertedEventCanBeQueriedByKey()
        {
            var found = await _dbContext.Event.Where(x => x.EventKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            foreach (var item in RecycleBin)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}