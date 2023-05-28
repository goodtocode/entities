using GoodToCode.Occurrences.Infrastructure;
using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventsGetSteps : ICrudSteps<Event>
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly EventCreateSteps createSteps = new();
        public Guid SutKey { get; set; }
        public Event Sut { get; private set; } = new();
        public IList<Event> Suts { get; private set; } = new List<Event>();
        public IList<Event> RecycleBin { get; set; } = new List<Event>();

        public EventsGetSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of Events")]
        public async Task GivenIRequestTheListOfEvents()
        {
            createSteps.GivenANewEventHasBeenCreated();
            await createSteps.WhenEventIsInsertedViaEntityFramework();
            Sut = await _dbContext.Event.FirstAsync();
            SutKey = Sut.EventKey;
        }

        [When(@"Events are queried via Entity framework")]
        public async Task WhenEventsAreQueriedViaEntityFrameworkAsync()
        {
            Sut = await _dbContext.Event.FirstOrDefaultAsync();
        }

        [Then(@"All persisted Events are returned")]
        public void ThenAllPersistedEventsAreReturned()
        {
            Assert.IsTrue(Sut.EventKey != Guid.Empty);
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
