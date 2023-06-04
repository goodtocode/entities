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
    public class ScheduleGetByKeySteps : ICrudSteps<Schedule>
    {        
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly ScheduleCreateSteps createSteps = new ScheduleCreateSteps();

        public Guid SutKey { get; private set; }
        public Schedule Sut { get; private set; } = new Schedule();
        public IList<Schedule> Suts { get; private set; } = new List<Schedule>();
        public IList<Schedule> RecycleBin { get; private set; } = new List<Schedule>();

        public ScheduleGetByKeySteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a Schedule key")]
        public async Task GivenIHaveAScheduleKey()
        {
            createSteps.GivenANewScheduleHasBeenCreated();
            await createSteps.WhenScheduleIsInsertedViaEntityFramework();
            Sut = await _dbContext.Schedule.FirstAsync();
            SutKey = Sut.ScheduleKey;
        }
        
        [Given(@"the key is type Guid")]
        public void GivenTheKeyIsTypeGuid()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }        
        
        [When(@"the Schedule exists in persistence")]
        public void WhenTheScheduleExistsInPersistence()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }
        
        [When(@"Schedule is queried by key via Entity framework")]
        public async Task WhenScheduleIsQueriedByKeyViaEntityFramework()
        {
            Sut = await _dbContext.Schedule.FirstAsync(x => x.ScheduleKey == SutKey);
            Assert.IsTrue(Sut.ScheduleKey != Guid.Empty);
        }
        
        [Then(@"the matching Schedule is returned")]
        public void ThenTheMatchingScheduleIsReturned()
        {
            Assert.IsTrue(Sut.ScheduleKey == SutKey);
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
