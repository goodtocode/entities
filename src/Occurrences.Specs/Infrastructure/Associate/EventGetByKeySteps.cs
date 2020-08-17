using GoodToCode.Shared.Specs;
using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Occurrences.Infrastructure;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventGetByKeySteps
    {        
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Event Sut { get; set; }

        public EventGetByKeySteps()
        {
            _config = new ConfigurationFactory("Occurrences.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a Event key")]
        public async Task GivenIHaveAEventKey()
        {
            var item = await _dbContext.Event.FirstAsync();
            SutKey = item.EventKey;
        }
        
        [Given(@"the key is type Guid")]
        public void GivenTheKeyIsTypeGuid()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }        
        
        [When(@"the Event exists in persistence")]
        public void WhenTheEventExistsInPersistence()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }
        
        [When(@"Event is queried by key via Entity framework")]
        public async Task WhenEventIsQueriedByKeyViaEntityFramework()
        {
            Sut = await _dbContext.Event.FirstAsync(x => x.EventKey == SutKey);
            Assert.IsTrue(Sut.EventKey != Guid.Empty);
        }
        
        [Then(@"the matching Event is returned")]
        public void ThenTheMatchingEventIsReturned()
        {
            Assert.IsTrue(Sut.EventKey == SutKey);
        }
    }
}
