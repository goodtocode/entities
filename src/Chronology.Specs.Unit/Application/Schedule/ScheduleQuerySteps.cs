using GoodToCode.Chronology.Application;
using GoodToCode.Chronology.Infrastructure;
using GoodToCode.Chronology.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class ScheduleQuerySteps : IQuerySteps<Schedule>
    {        
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly ScheduleSaveCommandSteps commandSteps = new ScheduleSaveCommandSteps();

        public Guid SutKey { get; private set; }
        public IList<Schedule> Sut { get; private set; } = new List<Schedule>();
        public IList<Schedule> RecycleBin { get; private set; } = new List<Schedule>();

        public ScheduleQuerySteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a Schedule key that can be Queried")]
        public async Task GivenIHaveAScheduleKeyThatCanBeQueried()
        {
            commandSteps.GivenANewScheduleSaveCommandHasBeenCreated();
            await commandSteps.WhenTheScheduleIsInsertedViaCQRSCommand();
            Sut = await _dbContext.Schedule.Take(10).ToListAsync();
            SutKey = Sut?.FirstOrDefault()?.ScheduleKey ?? Guid.Empty;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Schedule is read by key via Query")]
        public async Task WhenScheduleIsReadByKeyViaQueryAsync()
        {
            var query = new ScheduleGetQuery(SutKey);
            var handle = new ScheduleGetHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            Sut = response.Result;
        }

        [When(@"the Schedule exists in Query")]
        public void WhenTheScheduleExistsInQuery()
        {
            Assert.IsFalse(Sut == null);
        }

        [Then(@"the matching Schedule is returned from the Query")]
        public void ThenTheMatchingScheduleIsReturnedFromTheQuery()
        {
            Assert.IsTrue(Sut.Any(x => x.ScheduleKey == SutKey));
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
