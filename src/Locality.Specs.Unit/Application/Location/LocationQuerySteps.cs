using GoodToCode.Shared.Specs;
using GoodToCode.Locality.Application;
using GoodToCode.Locality.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Locality.Infrastructure;
using System.IO;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationQuerySteps : IQuerySteps<Location>
    {        
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly LocationSaveCommandSteps commandSteps = new LocationSaveCommandSteps();

        public Guid SutKey { get; private set; }
        public IList<Location> Sut { get; private set; }
        public IList<Location> RecycleBin { get; private set; } = new List<Location>();

        public LocationQuerySteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a Location key that can be Queried")]
        public async Task GivenIHaveALocationKeyThatCanBeQueried()
        {
            commandSteps.GivenANewLocationSaveCommandHasBeenCreated();
            await commandSteps.WhenTheLocationIsInsertedViaCQRSCommand();
            Sut = await _dbContext.Location.Take(10).ToListAsync();
            SutKey = Sut.FirstOrDefault().LocationKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Location is read by key via Query")]
        public async Task WhenLocationIsReadByKeyViaQueryAsync()
        {
            var query = new LocationGetQuery(SutKey);
            var handle = new LocationGetHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            Sut = response.Result;
        }

        [When(@"the Location exists in Query")]
        public void WhenTheLocationExistsInQuery()
        {
            Assert.IsFalse(Sut == null);
        }

        [Then(@"the matching Location is returned from the Query")]
        public void ThenTheMatchingLocationIsReturnedFromTheQuery()
        {
            Assert.IsTrue(Sut.Any(x => x.LocationKey == SutKey));
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
