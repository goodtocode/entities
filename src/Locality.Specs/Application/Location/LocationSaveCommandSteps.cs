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
using System.Collections.Generic;
using System.IO;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationSaveCommandSteps : ICommandSteps<Location>
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        public Guid SutKey { get; private set; }
        public Location Sut { get; private set; }
        public IList<Location> RecycleBin { get; private set; }

        public LocationSaveCommandSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Locality.Specs")).Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Location Save Command has been created")]
        public void GivenANewLocationSaveCommandHasBeenCreated()
        {
            SutKey = Guid.Empty;
            Sut = new Location()
            {
                LocationKey = SutKey,
                LocationName = "LocationSaveCommandSteps.cs Test"
            };
        }

        [Given(@"the Location Save Command validates")]
        public void GivenTheLocationSaveCommandValidates()
        {
            Assert.IsFalse(Sut.LocationName.IsNullOrWhiteSpace());
        }

        [When(@"the Location is inserted via CQRS Command")]
        public async Task WhenTheLocationIsInsertedViaCQRSCommand()
        {
            var query = new LocationSaveCommand(Sut);
            var handle = new LocationSaveHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            SutKey = response.Result.LocationKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [Then(@"the CQRS inserted Location can be queried by key")]
        public async Task ThenTheCQRSInsertedLocationCanBeQueriedByKey()
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