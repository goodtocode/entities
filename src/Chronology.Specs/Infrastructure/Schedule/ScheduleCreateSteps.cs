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
    public class ScheduleCreateSteps : ICrudSteps<Schedule>
    {
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;

        public Schedule Sut { get; set; }

        public Guid SutKey { get; set; }

        public IList<Schedule> RecycleBin { get; set; } = new List<Schedule>();

        public ScheduleCreateSteps()
        {
            _config = new ConfigurationFactory("Chronology.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Schedule has been created")]
        public void GivenANewScheduleHasBeenCreated()
        {
            SutKey = Guid.NewGuid();
            Sut = new Schedule()
            {
                ScheduleKey = SutKey,
                ScheduleName = "ScheduleCreateSteps.cs Test"
            };
        }

        [When(@"the Schedule does not exist in persistence by key")]
        public async Task WhenTheScheduleDoesNotExistInPersistenceByKey()
        {
            var found = await _dbContext.Schedule.Where(x => x.ScheduleKey == SutKey).AnyAsync();
            Assert.IsFalse(found);
        }

        [When(@"Schedule is inserted via Entity Framework")]
        public async Task WhenScheduleIsInsertedViaEntityFramework()
        {
            _dbContext.Schedule.Add(Sut);
            _rowsAffected = await _dbContext.SaveChangesAsync();
            SutKey = Sut.ScheduleKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the new Schedule can be queried by key")]
        public async Task ThenTheNewScheduleCanBeQueriedByKey()
        {
            var found = await _dbContext.Schedule.Where(x => x.ScheduleKey == SutKey).AnyAsync();
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
