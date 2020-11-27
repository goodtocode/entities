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
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessQuerySteps : IQuerySteps<Business>
    {        
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly BusinessSaveCommandSteps commandSteps = new BusinessSaveCommandSteps();

        public Guid SutKey { get; private set; }
        public IList<Business> Sut { get; private set; } = new List<Business>();
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public BusinessQuerySteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a business key that can be Queried")]
        public async Task GivenIHaveABusinessKeyThatCanBeQueried()
        {
            commandSteps.GivenANewBusinessSaveCommandHasBeenCreated();
            await commandSteps.WhenTheBusinessIsInsertedViaCQRSCommand();
            Sut.Add(await _dbContext.Business.FirstOrDefaultAsync());
            SutKey = Sut.FirstOrDefault().BusinessKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Business is read by key via Query")]
        public async Task WhenBusinessIsReadByKeyViaQueryAsync()
        {
            var query = new BusinessGetQuery(SutKey);
            var handle = new BusinessGetHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            Sut.Add(response.Result);
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
