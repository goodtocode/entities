using GoodToCode.Shared.Specs;
using GoodToCode.Locality.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Locality.Infrastructure;
using System;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationsGetSteps : ICrudSteps<Location>
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly LocationCreateSteps createSteps = new LocationCreateSteps();

        public Location Sut { get; set; }
        public Guid SutKey { get; set; }
        public IList<Location> RecycleBin { get; set; } = new List<Location>();

        public LocationsGetSteps()
        {
            _config = new ConfigurationFactory("Locality.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of Locationes")]
        public async Task GivenIRequestTheListOfLocationes()
        {
            createSteps.GivenANewLocationHasBeenCreated();
            await createSteps.WhenLocationIsInsertedViaEntityFramework();
            Sut = await _dbContext.Location.FirstOrDefaultAsync();
            SutKey = Sut.LocationKey;
        }

        [When(@"Locationes are queried via Entity framework")]
        public async Task WhenLocationesAreQueriedViaEntityFrameworkAsync()
        {
            Sut = await _dbContext.Location.FirstOrDefaultAsync();
        }

        [Then(@"All persisted Locationes are returned")]
        public void ThenAllPersistedLocationesAreReturned()
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
