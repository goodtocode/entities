using GoodToCode.Locality.Infrastructure;
using GoodToCode.Locality.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationsGetSteps : ICrudSteps<Location>
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly LocationCreateSteps createSteps = new LocationCreateSteps();

        public Location Sut { get; private set; } = new();
        public IList<Location> Suts { get; private set; } = new List<Location>();
        public Guid SutKey { get; private set; }
        public IList<Location> RecycleBin { get; set; } = new List<Location>();

        public LocationsGetSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of Location")]
        public async Task GivenIRequestTheListOfLocation()
        {
            createSteps.GivenANewLocationHasBeenCreated();
            await createSteps.WhenLocationIsInsertedViaEntityFramework();
            Sut = await _dbContext.Location.FirstOrDefaultAsync();
            SutKey = Sut.LocationKey;
        }

        [When(@"Location are queried via Entity framework")]
        public async Task WhenLocationAreQueriedViaEntityFramework()
        {
            Sut = await _dbContext.Location.FirstOrDefaultAsync();
        }

        [Then(@"All persisted Locations are returned")]
        public void ThenAllPersistedLocationsAreReturned()
        {
            Assert.IsTrue(Sut.LocationKey != Guid.Empty);
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
