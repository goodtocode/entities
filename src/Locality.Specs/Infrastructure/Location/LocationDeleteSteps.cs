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

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationDeleteSteps
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Location Sut { get; set; }

        public LocationDeleteSteps()
        {
            _config = new ConfigurationFactory("Locality.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An Location has been queried to be deleted")]
        public async Task GivenAnLocationHasBeenQueriedToBeDeleted()
        {
            Sut = await _dbContext.Location.Take(1).FirstOrDefaultAsync();
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


    }
}
