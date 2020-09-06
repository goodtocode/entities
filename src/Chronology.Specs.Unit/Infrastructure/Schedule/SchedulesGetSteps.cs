using GoodToCode.Shared.Specs;
using GoodToCode.Chronology.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Chronology.Infrastructure;
using System;
using System.Net.Http.Headers;
using System.IO;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class SchedulesGetSteps : ICrudSteps<Schedule>
    {
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly ScheduleCreateSteps createSteps = new ScheduleCreateSteps();

        public Schedule Sut { get; private set; }
        public IList<Schedule> Suts { get; private set; }
        public Guid SutKey { get; private set; }
        public IList<Schedule> RecycleBin { get; private set; } = new List<Schedule>();

        public SchedulesGetSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Chronology.Specs.Unit")).Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of Schedules")]
        public async Task GivenIRequestTheListOfSchedules()
        {
            createSteps.GivenANewScheduleHasBeenCreated();
            await createSteps.WhenScheduleIsInsertedViaEntityFramework();
            Sut = await _dbContext.Schedule.FirstOrDefaultAsync();
            SutKey = Sut.ScheduleKey;
        }

        [When(@"Schedules are queried via Entity framework")]
        public async Task WhenSchedulesAreQueriedViaEntityFrameworkAsync()
        {
            Suts = await _dbContext.Schedule.Take(10).ToListAsync();
            Sut = Suts.FirstOrDefault();
        }

        [Then(@"All persisted Schedules are returned")]
        public void ThenAllPersistedSchedulesAreReturned()
        {
            Assert.IsTrue(Sut.ScheduleKey != Guid.Empty);
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
