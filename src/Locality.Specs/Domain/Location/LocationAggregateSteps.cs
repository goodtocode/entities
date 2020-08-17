using GoodToCode.Locality.Infrastructure;
using GoodToCode.Locality.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationAggregateSteps
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;
        private Guid SutKey { get; set; }
        private Location Sut { get; set; }

        public LocationAggregateSteps()
        {
            _config = new ConfigurationFactory("Locality.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Location is created for the aggregate")]
        public void GivenANewLocationIsCreatedForTheAggregate()
        {
            SutKey = Guid.NewGuid();
            Sut = new Location()
            {
                LocationKey = SutKey,
                LocationName = "LocationAggregateSteps.cs Test"
            };
        }

        [When(@"the Location does not exist in persistence")]
        public async Task WhenTheLocationDoesNotExistInPersistence()
        {
            var found = await _dbContext.Location.Where(x => x.LocationKey == SutKey).AnyAsync();
            Assert.IsFalse(found);
        }

        [When(@"the Location is saved via the aggregate")]
        public async Task WhenTheLocationIsSavedViaTheAggregate()
        {
            var aggregate = new LocationAggregate(_dbContext);
            _rowsAffected = await aggregate.LocationSaveAsync(Sut);
            SutKey = Sut.LocationKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the aggregate inserted Location can be queried by key")]
        public async Task ThenTheAggregateInsertedLocationCanBeQueriedByKey()
        {
            var found = await _dbContext.Location.Where(x => x.LocationKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }
    }
}
