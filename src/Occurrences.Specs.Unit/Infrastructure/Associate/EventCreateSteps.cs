using GoodToCode.Shared.Specs;
using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Occurrences.Infrastructure;
using System.Collections.Generic;
using System.IO;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventCreateSteps : ICrudSteps<Event>
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;

        public Guid SutKey { get; set; }
        public Event Sut { get; private set; }
        public IList<Event> Suts { get; private set; } = new List<Event>();        

        public IList<Event> RecycleBin { get; set; } = new List<Event>();

        public EventCreateSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Event has been created")]
        public void GivenANewEventHasBeenCreated()
        {
            SutKey = Guid.Empty;
            Sut = new Event()
            {
                EventKey = SutKey,
                EventName = "EventCreateSteps.cs Test"
            };
        }

        [When(@"the Event does not exist in persistence by key")]
        public async Task WhenTheEventDoesNotExistInPersistenceByKey()
        {
            var found = await _dbContext.Event.Where(x => x.EventKey == SutKey).AnyAsync();
            Assert.IsFalse(found);
        }

        [When(@"Event is inserted via Entity Framework")]
        public async Task WhenEventIsInsertedViaEntityFramework()
        {
            _dbContext.Event.Add(Sut);
            _rowsAffected = await _dbContext.SaveChangesAsync();
            SutKey = Sut.EventKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the new Event can be queried by key")]
        public async Task ThenTheNewEventCanBeQueriedByKey()
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
