using GoodToCode.Shared.Specs;
using GoodToCode.Locality.Application;
using GoodToCode.Locality.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecRun.Common.Helper;
using GoodToCode.Locality.Infrastructure;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationSaveCommandSteps
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Location Sut { get; set; }

        public LocationSaveCommandSteps()
        {
            _config = new ConfigurationFactory("Locality.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Location Save Command has been created")]
        public void GivenANewLocationSaveCommandHasBeenCreated()
        {
            SutKey = Guid.NewGuid();
            Sut = new Location()
            {
                LocationKey = SutKey,
                LocationName = "LocationSaveCommandSteps.cs Test"
            };
        }

        [Given(@"the Location Save Command validates")]
        public void GivenTheLocationSaveCommandValidates()
        {
            Assert.IsTrue(Sut.LocationKey != Guid.Empty);
            Assert.IsFalse(Sut.LocationName.IsNullOrWhiteSpace());
        }

        [When(@"the Location is inserted via CQRS Command")]
        public async Task WhenTheLocationIsInsertedViaCQRSCommand()
        {
            var query = new LocationSaveCommand(Sut);
            var handle = new LocationSaveHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            Assert.IsTrue(response.Result);
        }

        [Then(@"the CQRS inserted Location can be queried by key")]
        public async Task ThenTheCQRSInsertedLocationCanBeQueriedByKey()
        {
            var found = await _dbContext.Location.Where(x => x.LocationKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }
    }
}