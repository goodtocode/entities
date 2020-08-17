using GoodToCode.Shared.Specs;
using GoodToCode.Chronology.Application;
using GoodToCode.Chronology.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Chronology.Infrastructure;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class ScheduleQuerySteps
    {        
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private List<Schedule> Sut { get; set; }

        public ScheduleQuerySteps()
        {
            _config = new ConfigurationFactory("Chronology.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a Schedule key that can be Queried")]
        public async Task GivenIHaveAScheduleKeyThatCanBeQueried()
        {
            var item = await _dbContext.Schedule.FirstAsync();
            SutKey = item.ScheduleKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Schedule is read by key via Query")]
        public async Task WhenScheduleIsReadByKeyViaQueryAsync()
        {
            var query = new ScheduleGetQuery(SutKey);
            var handle = new ScheduleGetHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            Sut = response.Result;
        }

        [When(@"the Schedule exists in Query")]
        public void WhenTheScheduleExistsInQuery()
        {
            Assert.IsFalse(Sut == null);
        }

        [Then(@"the matching Schedule is returned from the Query")]
        public void ThenTheMatchingScheduleIsReturnedFromTheQuery()
        {
            Assert.IsTrue(Sut.Any(x => x.ScheduleKey == SutKey));
        }
    }
}
