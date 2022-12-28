using GoodToCode.Chronology.Application;
using GoodToCode.Chronology.Infrastructure;
using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;


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
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Schedule Save Command has been created")]
        public void GivenANewScheduleSaveCommandHasBeenCreated()
        {
            SutKey = Guid.Empty;
            Sut = new Schedule()
            {
                ScheduleKey = SutKey,
                ScheduleName = "ScheduleSaveCommandSteps.cs Test"                              
            };
        }

        [Given(@"the Schedule Save Command validates")]
        public void GivenTheScheduleSaveCommandValidates()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(Sut.ScheduleName));
        }

        [When(@"the Schedule is inserted via CQRS Command")]
        public async Task WhenTheScheduleIsInsertedViaCQRSCommand()
        {
            var query = new ScheduleSaveCommand(Sut);
            var handle = new ScheduleSaveHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            SutKey = response.Result.ScheduleKey;
            Assert.IsTrue(SutKey != Guid.Empty);
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