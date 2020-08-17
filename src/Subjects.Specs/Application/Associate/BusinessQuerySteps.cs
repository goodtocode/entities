using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Application;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessQuerySteps
    {        
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private List<Business> Sut { get; set; }

        public BusinessQuerySteps()
        {
            _config = new ConfigurationFactory("Subjects.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a business key that can be Queried")]
        public async Task GivenIHaveABusinessKeyThatCanBeQueried()
        {
            var item = await _dbContext.Business.FirstAsync();
            SutKey = item.BusinessKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Business is read by key via Query")]
        public async Task WhenBusinessIsReadByKeyViaQueryAsync()
        {
            var query = new BusinessGetQuery(SutKey);
            var handle = new BusinessGetHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            Sut = response.Result;
        }

        [When(@"the business exists in Query")]
        public void WhenTheBusinessExistsInQuery()
        {
            Assert.IsFalse(Sut == null);
        }

        [Then(@"the matching business is returned from the Query")]
        public void ThenTheMatchingBusinessIsReturnedFromTheQuery()
        {
            Assert.IsTrue(Sut.Any(x => x.BusinessKey == SutKey));
        }
    }
}
