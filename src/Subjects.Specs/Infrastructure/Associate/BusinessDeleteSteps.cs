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
    public class BusinessDeleteSteps
    {
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Business Sut { get; set; }

        public BusinessDeleteSteps()
        {
            _config = new ConfigurationFactory("Subjects.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An Business has been queried to be deleted")]
        public async Task GivenAnBusinessHasBeenQueriedToBeDeleted()
        {
            Sut = await _dbContext.Business.Take(1).FirstOrDefaultAsync();
            SutKey = Sut.BusinessKey;
        }

        [Given(@"a business to be deleted was found in persistence")]
        public void GivenABusinessToBeDeletedWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }

        [When(@"the Business is Deleted via Entity Framework")]
        public async Task WhenTheBusinessIsDeletedViaEntityFramework()
        {
            _dbContext.Entry(Sut).State = EntityState.Deleted;
            var result = await _dbContext.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the deleted business is queried by key")]
        public async Task ThenTheDeletedBusinessIsQueriedByKey()
        {
            Sut = await _dbContext.Business.FirstOrDefaultAsync(x => x.BusinessKey == SutKey);
        }

        [Then(@"the Business is not found")]
        public void ThenTheBusinessIsNotFound()
        {
            Assert.IsTrue(Sut?.BusinessKey != SutKey);
        }


    }
}
