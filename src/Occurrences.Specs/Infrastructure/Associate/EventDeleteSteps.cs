using GoodToCode.Shared.Specs;
using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Occurrences.Infrastructure;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventDeleteSteps
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Event Sut { get; set; }

        public EventDeleteSteps()
        {
            _config = new ConfigurationFactory("Occurrences.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An Event has been queried to be deleted")]
        public async Task GivenAnEventHasBeenQueriedToBeDeleted()
        {
            Sut = await _dbContext.Event.Take(1).FirstOrDefaultAsync();
            SutKey = Sut.EventKey;
        }

        [Given(@"a Event to be deleted was found in persistence")]
        public void GivenAEventToBeDeletedWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.EventKey != Guid.Empty);
        }

        [When(@"the Event is Deleted via Entity Framework")]
        public async Task WhenTheEventIsDeletedViaEntityFramework()
        {
            _dbContext.Entry(Sut).State = EntityState.Deleted;
            var result = await _dbContext.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the deleted Event is queried by key")]
        public async Task ThenTheDeletedEventIsQueriedByKey()
        {
            Sut = await _dbContext.Event.FirstOrDefaultAsync(x => x.EventKey == SutKey);
        }

        [Then(@"the Event is not found")]
        public void ThenTheEventIsNotFound()
        {
            Assert.IsTrue(Sut?.EventKey != SutKey);
        }


    }
}
