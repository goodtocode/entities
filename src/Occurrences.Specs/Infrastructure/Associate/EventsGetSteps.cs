using GoodToCode.Shared.Specs;
using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Occurrences.Infrastructure;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventesGetSteps
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private List<Event> Sut { get; set; }

        public EventesGetSteps()
        {
            _config = new ConfigurationFactory("Occurrences.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of Eventes")]
        public void GivenIRequestTheListOfEventes()
        {
            Sut = new List<Event>();
        }

        [When(@"Eventes are queried via Entity framework")]
        public async Task WhenEventesAreQueriedViaEntityFrameworkAsync()
        {
            Sut = await _dbContext.Event.Take(10).ToListAsync();
        }

        [Then(@"All persisted Eventes are returned")]
        public void ThenAllPersistedEventesAreReturned()
        {
            Assert.IsTrue(Sut.Any());
        }
    }
}
