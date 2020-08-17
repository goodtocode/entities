using GoodToCode.Shared.Specs;
using GoodToCode.Chronology.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Chronology.Infrastructure;

namespace GoodToCode.Chronology.Specs
{
    [Binding]
    public class ScheduleesGetSteps
    {
        private readonly ChronologyDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private List<Schedule> Sut { get; set; }

        public ScheduleesGetSteps()
        {
            _config = new ConfigurationFactory("Chronology.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of Schedulees")]
        public void GivenIRequestTheListOfSchedulees()
        {
            Sut = new List<Schedule>();
        }

        [When(@"Schedulees are queried via Entity framework")]
        public async Task WhenScheduleesAreQueriedViaEntityFrameworkAsync()
        {
            Sut = await _dbContext.Schedule.Take(10).ToListAsync();
        }

        [Then(@"All persisted Schedulees are returned")]
        public void ThenAllPersistedScheduleesAreReturned()
        {
            Assert.IsTrue(Sut.Any());
        }
    }
}
