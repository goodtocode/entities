using GoodToCode.Shared.Specs;
using GoodToCode.Chronology.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Chronology.Infrastructure;
using System.Collections.Generic;
using System.IO;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class ScheduleUpdateSteps : ICrudSteps<Schedule>
    {
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly ScheduleCreateSteps createSteps = new ScheduleCreateSteps();
        private string SutName { get; set; }
        private string SutNameNew { get; set; }
        
        public Guid SutKey { get; private set; }
        public Schedule Sut { get; private set; }
        public IList<Schedule> Suts { get; private set; } = new List<Schedule>();
        public IList<Schedule> RecycleBin { get; private set; } = new List<Schedule>();

        public ScheduleUpdateSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Chronology.Specs.Unit")).Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An existing Schedule has been queried")]
        public async Task GivenAnExistingScheduleHasBeenQueried()
        {
            createSteps.GivenANewScheduleHasBeenCreated();
            await createSteps.WhenScheduleIsInsertedViaEntityFramework();
            Sut = await _dbContext.Schedule.FirstAsync();
            SutKey = Sut.ScheduleKey;
        }

        [Given(@"a Schedule was found in persistence")]
        public void GivenAScheduleWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.ScheduleKey != Guid.Empty);
        }

        [When(@"the Schedule name changes")]
        public void WhenTheScheduleNameChanges()
        {
            SutKey = Sut.ScheduleKey;
            SutName = Sut.ScheduleName;
            SutNameNew = $"Schedule name as of {DateTime.UtcNow.ToShortTimeString()}";
            Sut.ScheduleName = SutNameNew;
        }

        [When(@"Schedule is Updated via Entity Framework")]
        public async Task WhenScheduleIsUpdatedViaEntityFramework()
        {
            _dbContext.Entry(Sut).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the existing Schedule can be queried by key")]
        public async Task ThenTheExistingScheduleCanBeQueriedByKey()
        {
            Sut = await _dbContext.Schedule.FirstOrDefaultAsync(x => x.ScheduleKey == SutKey);
        }

        [Then(@"the Schedule name matches the new name")]
        public void ThenTheScheduleNameMatchesTheNewName()
        {
            Assert.IsTrue(SutNameNew == Sut.ScheduleName);
            Assert.IsFalse(SutNameNew == SutName);
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
