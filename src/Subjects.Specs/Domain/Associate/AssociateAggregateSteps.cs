using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class AssociateAggregateSteps
    {
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;
        private Guid SutKey { get; set; }
        private Business Sut { get; set; }

        public AssociateAggregateSteps()
        {
            _config = new ConfigurationFactory("Subjects.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Business is created for the aggregate")]
        public void GivenANewBusinessIsCreatedForTheAggregate()
        {
            SutKey = Guid.NewGuid();
            Sut = new Business()
            {
                BusinessKey = SutKey,
                BusinessName = "AssociateAggregateSteps.cs Test",
                TaxNumber = string.Empty,
                
                
            };
        }

        [When(@"the business does not exist in persistence")]
        public async Task WhenTheBusinessDoesNotExistInPersistence()
        {
            var found = await _dbContext.Business.Where(x => x.BusinessKey == SutKey).AnyAsync();
            Assert.IsFalse(found);
        }

        [When(@"the business is saved via the aggregate")]
        public async Task WhenTheBusinessIsSavedViaTheAggregate()
        {
            var aggregate = new AssociateAggregate(_dbContext);
            _rowsAffected = await aggregate.BusinessSaveAsync(Sut);
            SutKey = Sut.BusinessKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the aggregate inserted business can be queried by key")]
        public async Task ThenTheAggregateInsertedBusinessCanBeQueriedByKey()
        {
            var found = await _dbContext.Business.Where(x => x.BusinessKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }
    }
}
