using GoodToCode.Shared.Specs;
using GoodToCode.Chronology.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Chronology.Infrastructure;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class ScheduleGetByKeySteps
    {        
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Schedule Sut { get; set; }

        public ScheduleGetByKeySteps()
        {
            _config = new ConfigurationFactory("Chronology.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a Schedule key")]
        public async Task GivenIHaveAScheduleKey()
        {
            var item = await _dbContext.Schedule.FirstAsync();
            SutKey = item.ScheduleKey;
        }
        
        [Given(@"the key is type Guid")]
        public void GivenTheKeyIsTypeGuid()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }        
        
        [When(@"the Schedule exists in persistence")]
        public void WhenTheScheduleExistsInPersistence()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }
        
        [When(@"Schedule is queried by key via Entity framework")]
        public async Task WhenScheduleIsQueriedByKeyViaEntityFramework()
        {
            Sut = await _dbContext.Schedule.FirstAsync(x => x.ScheduleKey == SutKey);
            Assert.IsTrue(Sut.ScheduleKey != Guid.Empty);
        }
        
        [Then(@"the matching Schedule is returned")]
        public void ThenTheMatchingScheduleIsReturned()
        {
            Assert.IsTrue(Sut.ScheduleKey == SutKey);
        }
    }
}
