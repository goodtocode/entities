using GoodToCode.Chronology.Infrastructure;
using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class ScheduleAggregateSteps : IAggregateSteps<ScheduleAggregate>
    {
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;

        public Guid SutKey { get; private set; }
        public ScheduleAggregate Aggregate { get; private set; }
        public IList<ScheduleAggregate> RecycleBin { get; private set; }

        public Schedule SutSchedule { get; private set; }

        public ScheduleAggregateSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
            Aggregate = new ScheduleAggregate(_dbContext);
        }

        [Given(@"A new Schedule is created for the aggregate")]
        public void GivenANewScheduleIsCreatedForTheAggregate()
        {
            SutKey = Guid.Empty;
            SutSchedule = new Schedule()
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
            _rowsAffected = await Aggregate.ScheduleSaveAsync(SutSchedule);
            SutKey = SutSchedule.ScheduleKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the aggregate inserted Schedule can be queried by key")]
        public async Task ThenTheAggregateInsertedScheduleCanBeQueriedByKey()
        {
            var found = await _dbContext.Schedule.Where(x => x.ScheduleKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await Aggregate.ScheduleDeleteAsync(SutSchedule);
        }
    }
}
