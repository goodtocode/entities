using GoodToCode.Chronology.Infrastructure;
using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class SchedulesGetSteps : ICrudSteps<Schedule>
    {
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly ScheduleCreateSteps createSteps = new ScheduleCreateSteps();

        public Schedule Sut { get; private set; } = new();
        public IList<Schedule> Suts { get; private set; } = new List<Schedule>();
        public Guid SutKey { get; private set; }
        public IList<Schedule> RecycleBin { get; private set; } = new List<Schedule>();

        public SchedulesGetSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
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
            Sut = Suts?.FirstOrDefault() ?? new Schedule();
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
