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
using System.IO;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationUpdateSteps : ICrudSteps<Location>
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly LocationCreateSteps createSteps = new LocationCreateSteps();
        
        private string SutName { get; set; }
        private string SutNameNew { get; set; }

        public Location Sut { get; private set; }
        public IList<Location> Suts { get; private set; }
        public Guid SutKey { get; set; }
        public IList<Location> RecycleBin { get; set; } = new List<Location>();

        public LocationUpdateSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Locality.Specs")).Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An existing Location has been queried")]
        public async Task GivenAnExistingLocationHasBeenQueried()
        {
            createSteps.GivenANewLocationHasBeenCreated();
            await createSteps.WhenLocationIsInsertedViaEntityFramework();
            Sut = await _dbContext.Location.FirstAsync();
            SutKey = Sut.LocationKey;
        }

        [Given(@"a Location was found in persistence")]
        public void GivenALocationWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.LocationKey != Guid.Empty);
        }

        [When(@"the Location name changes")]
        public void WhenTheLocationNameChanges()
        {
            SutKey = Sut.LocationKey;
            SutName = Sut.LocationName;
            SutNameNew = $"Location name as of {DateTime.UtcNow.ToShortTimeString()}";
            Sut.LocationName = SutNameNew;
        }

        [When(@"Location is Updated via Entity Framework")]
        public async Task WhenLocationIsUpdatedViaEntityFramework()
        {
            _dbContext.Entry(Sut).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the existing Location can be queried by key")]
        public async Task ThenTheExistingLocationCanBeQueriedByKey()
        {
            Sut = await _dbContext.Location.FirstOrDefaultAsync(x => x.LocationKey == SutKey);
        }

        [Then(@"the Location name matches the new name")]
        public void ThenTheLocationNameMatchesTheNewName()
        {
            Assert.IsTrue(SutNameNew == Sut.LocationName);
            Assert.IsFalse(SutNameNew == SutName);
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
