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
    public class EventUpdateSteps
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private string SutName { get; set; }
        private string SutNameNew { get; set; }
        private Event Sut { get; set; }

        public EventUpdateSteps()
        {
            _config = new ConfigurationFactory("Occurrences.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An existing Event has been queried")]
        public async Task GivenAnExistingEventHasBeenQueried()
        {
            Sut = await _dbContext.Event.Take(1).FirstOrDefaultAsync();
        }

        [Given(@"a Event was found in persistence")]
        public void GivenAEventWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.EventKey != Guid.Empty);
        }

        [When(@"the Event name changes")]
        public void WhenTheEventNameChanges()
        {
            SutKey = Sut.EventKey;
            SutName = Sut.EventName;
            SutNameNew = $"Event name as of {DateTime.UtcNow.ToShortTimeString()}";
            Sut.EventName = SutNameNew;
        }

        [When(@"Event is Updated via Entity Framework")]
        public async Task WhenEventIsUpdatedViaEntityFramework()
        {
            _dbContext.Entry(Sut).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the existing Event can be queried by key")]
        public async Task ThenTheExistingEventCanBeQueriedByKey()
        {
            Sut = await _dbContext.Event.FirstOrDefaultAsync(x => x.EventKey == SutKey);
        }

        [Then(@"the Event name matches the new name")]
        public void ThenTheEventNameMatchesTheNewName()
        {
            Assert.IsTrue(SutNameNew == Sut.EventName);
            Assert.IsFalse(SutNameNew == SutName);
        }

    }
}
