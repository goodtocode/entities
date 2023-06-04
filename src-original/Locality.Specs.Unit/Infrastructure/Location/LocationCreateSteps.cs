﻿using GoodToCode.Locality.Infrastructure;
using GoodToCode.Locality.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationCreateSteps : ICrudSteps<Location>
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;
        public Guid SutKey { get; private set; }
        public Location Sut { get; private set; } = new();
        public IList<Location> Suts { get; private set; } = new List<Location>();
        public IList<Location> RecycleBin { get; private set; } = new List<Location>();

        public LocationCreateSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Location has been created")]
        public void GivenANewLocationHasBeenCreated()
        {
            SutKey = Guid.Empty;
            Sut = new Location()
            {
                LocationKey = SutKey,
                LocationName = "LocationCreateSteps.cs Test"
            };
        }

        [When(@"the Location does not exist in persistence by key")]
        public async Task WhenTheLocationDoesNotExistInPersistenceByKey()
        {
            var found = await _dbContext.Location.Where(x => x.LocationKey == SutKey).AnyAsync();
            Assert.IsFalse(found);
        }

        [When(@"Location is inserted via Entity Framework")]
        public async Task WhenLocationIsInsertedViaEntityFramework()
        {
            _dbContext.Location.Add(Sut);
            _rowsAffected = await _dbContext.SaveChangesAsync();
            SutKey = Sut.LocationKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the new Location can be queried by key")]
        public async Task ThenTheNewLocationCanBeQueriedByKey()
        {
            var found = await _dbContext.Location.Where(x => x.LocationKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
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