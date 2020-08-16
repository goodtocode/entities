using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessesGetSteps
    {
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private List<Business> Sut { get; set; }

        public BusinessesGetSteps()
        {
            _config = new ConfigurationFactory("Subjects.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of businesses")]
        public void GivenIRequestTheListOfBusinesses()
        {
            Sut = new List<Business>();
        }

        [When(@"Businesses are queried via Entity framework")]
        public async Task WhenBusinessesAreQueriedViaEntityFrameworkAsync()
        {
            Sut = await _dbContext.Business.Take(10).ToListAsync();
        }

        [Then(@"All persisted businesses are returned")]
        public void ThenAllPersistedBusinessesAreReturned()
        {
            Assert.IsTrue(Sut.Any());
        }
    }
}
