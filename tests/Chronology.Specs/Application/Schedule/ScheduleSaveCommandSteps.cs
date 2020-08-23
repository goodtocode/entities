using GoodToCode.Chronology.Application;
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
using TechTalk.SpecRun.Common.Helper;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class ScheduleSaveCommandSteps : ICommandSteps<Schedule>
    {
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        public Guid SutKey { get; private set; }
        public Schedule Sut { get; private set; }
        public IList<Schedule> RecycleBin { get; private set; }

        public ScheduleSaveCommandSteps()
        {
            _config = new ConfigurationFactory("Chronology.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Schedule Save Command has been created")]
        public void GivenANewScheduleSaveCommandHasBeenCreated()
        {
            SutKey = Guid.NewGuid();
            Sut = new Schedule()
            {
                ScheduleKey = SutKey,
                ScheduleName = "ScheduleSaveCommandSteps.cs Test"                              
            };
        }

        [Given(@"the Schedule Save Command validates")]
        public void GivenTheScheduleSaveCommandValidates()
        {
            Assert.IsTrue(Sut.ScheduleKey != Guid.Empty);
            Assert.IsFalse(Sut.ScheduleName.IsNullOrWhiteSpace());
        }

        [When(@"the Schedule is inserted via CQRS Command")]
        public async Task WhenTheScheduleIsInsertedViaCQRSCommand()
        {
            var query = new ScheduleSaveCommand(Sut);
            var handle = new ScheduleSaveHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            Assert.IsTrue(response.Result);
        }

        [Then(@"the CQRS inserted Schedule can be queried by key")]
        public async Task ThenTheCQRSInsertedScheduleCanBeQueriedByKey()
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