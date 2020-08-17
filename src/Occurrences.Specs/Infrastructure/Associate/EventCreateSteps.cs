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

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventCreateSteps
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;
        private Guid SutKey { get; set; }
        private Event Sut { get; set; }

        public EventCreateSteps()
        {
            _config = new ConfigurationFactory("Occurrences.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Event has been created")]
        public void GivenANewEventHasBeenCreated()
        {
            SutKey = Guid.NewGuid();
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
    }
}
