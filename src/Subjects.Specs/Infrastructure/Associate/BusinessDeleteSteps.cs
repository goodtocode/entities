using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
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
    public class BusinessDeleteSteps : ICrudSteps<Business>
    {
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly BusinessCreateSteps createSteps = new BusinessCreateSteps();

        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; }
        public IList<Business> RecycleBin { get; set; } = new List<Business>();

        public BusinessDeleteSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs")).Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An Business has been queried to be deleted")]
        public async Task GivenAnBusinessHasBeenQueriedToBeDeleted()
        {
            createSteps.GivenANewBusinessHasBeenCreated();
            await createSteps.WhenBusinessIsInsertedViaEntityFramework();
            Sut = await _dbContext.Business.FirstAsync();
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
