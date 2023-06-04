using GoodToCode.Locality.Application;
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
    public class LocationSaveCommandSteps : ICommandSteps<Location>
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        public Guid SutKey { get; private set; }
        public Location Sut { get; private set; } = new();
        public IList<Location> RecycleBin { get; private set; } = new List<Location>();

        public LocationSaveCommandSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
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
            Assert.IsFalse(string.IsNullOrWhiteSpace(Sut.LocationName));
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