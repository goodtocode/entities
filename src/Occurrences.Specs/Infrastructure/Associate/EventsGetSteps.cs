using GoodToCode.Shared.Specs;
using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Occurrences.Infrastructure;
using System;
using System.IO;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventsGetSteps : ICrudSteps<Event>
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly EventCreateSteps createSteps = new EventCreateSteps();
        public Guid SutKey { get; set; }
        public Event Sut { get; private set; }
        public IList<Event> Suts { get; private set; }
        public IList<Event> RecycleBin { get; set; } = new List<Event>();

        public EventsGetSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Occurrences.Specs")).Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of Events")]
        public async Task GivenIRequestTheListOfEvents()
        {
            createSteps.GivenANewEventHasBeenCreated();
            await createSteps.WhenEventIsInsertedViaEntityFramework();
            Sut = await _dbContext.Event.FirstAsync();
            SutKey = Sut.EventKey;
        }

        [When(@"Events are queried via Entity framework")]
        public async Task WhenEventsAreQueriedViaEntityFrameworkAsync()
        {
            Sut = await _dbContext.Event.FirstOrDefaultAsync();
        }

        [Then(@"All persisted Events are returned")]
        public void ThenAllPersistedEventsAreReturned()
        {
            Assert.IsTrue(Sut.EventKey != Guid.Empty);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            foreach (var item in RecycleBin)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            await createSteps.Cleanup();
        }
    }
}
