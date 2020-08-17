using GoodToCode.Shared.Specs;
using GoodToCode.Locality.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Locality.Infrastructure;

namespace GoodToCode.Locality.Specs
{
    [Binding]
    public class LocationesGetSteps
    {
        private readonly LocalityDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private List<Location> Sut { get; set; }

        public LocationesGetSteps()
        {
            _config = new ConfigurationFactory("Locality.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of Locationes")]
        public void GivenIRequestTheListOfLocationes()
        {
            Sut = new List<Location>();
        }

        [When(@"Locationes are queried via Entity framework")]
        public async Task WhenLocationesAreQueriedViaEntityFrameworkAsync()
        {
            Sut = await _dbContext.Location.Take(10).ToListAsync();
        }

        [Then(@"All persisted Locationes are returned")]
        public void ThenAllPersistedLocationesAreReturned()
        {
            Assert.IsTrue(Sut.Any());
        }
    }
}
