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
    public class LocationGetByKeySteps : ICrudSteps<Location>
    {        
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly LocationCreateSteps createSteps = new LocationCreateSteps();

        public Guid SutKey { get; private set; }
        public Location Sut { get; private set; } = new();
        public IList<Location> Suts { get; private set; } = new List<Location>();

        public IList<Location> RecycleBin { get; private set; } = new List<Location>();

        public LocationGetByKeySteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a Location key")]
        public async Task GivenIHaveALocationKey()
        {
            createSteps.GivenANewLocationHasBeenCreated();
            await createSteps.WhenLocationIsInsertedViaEntityFramework();
            Sut = await _dbContext.Location.FirstAsync();
            SutKey = Sut.LocationKey;
        }
        
        [Given(@"the key is type Guid")]
        public void GivenTheKeyIsTypeGuid()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }        
        
        [When(@"the Location exists in persistence")]
        public void WhenTheLocationExistsInPersistence()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }
        
        [When(@"Location is queried by key via Entity framework")]
        public async Task WhenLocationIsQueriedByKeyViaEntityFramework()
        {
            Sut = await _dbContext.Location.FirstAsync(x => x.LocationKey == SutKey);
            Assert.IsTrue(Sut.LocationKey != Guid.Empty);
        }
        
        [Then(@"the matching Location is returned")]
        public void ThenTheMatchingLocationIsReturned()
        {
            Assert.IsTrue(Sut.LocationKey == SutKey);
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
