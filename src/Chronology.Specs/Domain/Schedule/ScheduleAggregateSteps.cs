using GoodToCode.Chronology.Infrastructure;
using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class ScheduleAggregateSteps
    {
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;
        private Guid SutKey { get; set; }
        private Schedule Sut { get; set; }

        public ScheduleAggregateSteps()
        {
            _config = new ConfigurationFactory("Chronology.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Schedule is created for the aggregate")]
        public void GivenANewScheduleIsCreatedForTheAggregate()
        {
            SutKey = Guid.NewGuid();
            Sut = new Schedule()
            {
                ScheduleKey = SutKey,
                ScheduleName = "ScheduleAggregateSteps.cs Test"
            };
        }

        [When(@"the Schedule does not exist in persistence")]
        public async Task WhenTheScheduleDoesNotExistInPersistence()
        {
            var found = await _dbContext.Schedule.Where(x => x.ScheduleKey == SutKey).AnyAsync();
            Assert.IsFalse(found);
        }

        [When(@"the Schedule is saved via the aggregate")]
        public async Task WhenTheScheduleIsSavedViaTheAggregate()
        {
            var aggregate = new ScheduleAggregate(_dbContext);
            _rowsAffected = await aggregate.ScheduleSaveAsync(Sut);
            SutKey = Sut.ScheduleKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the aggregate inserted Schedule can be queried by key")]
        public async Task ThenTheAggregateInsertedScheduleCanBeQueriedByKey()
        {
            var found = await _dbContext.Schedule.Where(x => x.ScheduleKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }
    }
}
