using GoodToCode.Shared.Specs;
using GoodToCode.Locality.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Locality.Infrastructure;
using System.Collections.Generic;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationDeleteSteps : ICrudSteps<Location>
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly LocationCreateSteps createSteps = new LocationCreateSteps();

        public Guid SutKey { get; private set; }
        public Location Sut { get; private set; }
        public IList<Location> RecycleBin { get; private set; } = new List<Location>();

        public LocationDeleteSteps()
        {
            _config = new ConfigurationFactory("Locality.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An Location has been queried to be deleted")]
        public async Task GivenAnLocationHasBeenQueriedToBeDeleted()
        {
            createSteps.GivenANewLocationHasBeenCreated();
            await createSteps.WhenLocationIsInsertedViaEntityFramework();
            Sut = await _dbContext.Location.FirstAsync();
            SutKey = Sut.LocationKey;
        }

        [Given(@"a Location to be deleted was found in persistence")]
        public void GivenALocationToBeDeletedWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.LocationKey != Guid.Empty);
        }

        [When(@"the Location is Deleted via Entity Framework")]
        public async Task WhenTheLocationIsDeletedViaEntityFramework()
        {
            _dbContext.Entry(Sut).State = EntityState.Deleted;
            var result = await _dbContext.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the deleted Location is queried by key")]
        public async Task ThenTheDeletedLocationIsQueriedByKey()
        {
            Sut = await _dbContext.Location.FirstOrDefaultAsync(x => x.LocationKey == SutKey);
        }

        [Then(@"the Location is not found")]
        public void ThenTheLocationIsNotFound()
        {
            Assert.IsTrue(Sut?.LocationKey != SutKey);
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
