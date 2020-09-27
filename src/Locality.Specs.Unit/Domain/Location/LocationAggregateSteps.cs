using GoodToCode.Locality.Infrastructure;
using GoodToCode.Locality.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationAggregateSteps : IAggregateSteps<LocationAggregate>
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;

        public Guid SutKey { get; private set; }
        public LocationAggregate Aggregate { get; private set; }
        public IList<LocationAggregate> RecycleBin { get; private set; }

        public Location SutLocation { get; private set; }

        public LocationAggregateSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings();
            _dbContext = new DbContextFactory(_connectionString).Create();
            Aggregate = new LocationAggregate(_dbContext);
        }

        [Given(@"A new Location is created for the aggregate")]
        public void GivenANewLocationIsCreatedForTheAggregate()
        {
            SutKey = Guid.Empty;
            SutLocation = new Location()
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
            _rowsAffected = await Aggregate.LocationSaveAsync(SutLocation);
            SutKey = SutLocation.LocationKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the aggregate inserted Location can be queried by key")]
        public async Task ThenTheAggregateInsertedLocationCanBeQueriedByKey()
        {
            var found = await _dbContext.Location.Where(x => x.LocationKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await Aggregate.LocationDeleteAsync(SutLocation);
        }
    }
}
