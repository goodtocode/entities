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
    public class ScheduleDeleteSteps : ICrudSteps<Schedule>
    {
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly ScheduleCreateSteps createSteps = new ScheduleCreateSteps();

        public Guid SutKey { get; private set; }
        public Schedule Sut { get; private set; }
        public IList<Schedule> Suts { get; private set; } = new List<Schedule>();
        public IList<Schedule> RecycleBin { get; private set; } = new List<Schedule>();

        public ScheduleDeleteSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An Schedule has been queried to be deleted")]
        public async Task GivenAnScheduleHasBeenQueriedToBeDeleted()
        {
            createSteps.GivenANewScheduleHasBeenCreated();
            await createSteps.WhenScheduleIsInsertedViaEntityFramework();
            Sut = await _dbContext.Schedule.FirstAsync();
            SutKey = Sut.ScheduleKey;
        }

        [Given(@"a Schedule to be deleted was found in persistence")]
        public void GivenAScheduleToBeDeletedWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.ScheduleKey != Guid.Empty);
        }

        [When(@"the Schedule is Deleted via Entity Framework")]
        public async Task WhenTheScheduleIsDeletedViaEntityFramework()
        {
            _dbContext.Entry(Sut).State = EntityState.Deleted;
            var result = await _dbContext.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the deleted Schedule is queried by key")]
        public async Task ThenTheDeletedScheduleIsQueriedByKey()
        {
            Sut = await _dbContext.Schedule.FirstOrDefaultAsync(x => x.ScheduleKey == SutKey);
        }

        [Then(@"the Schedule is not found")]
        public void ThenTheScheduleIsNotFound()
        {
            Assert.IsTrue(Sut?.ScheduleKey != SutKey);
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
