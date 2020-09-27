using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessGetByKeySteps : ICrudSteps<Business>
    {        
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly BusinessCreateSteps createSteps = new BusinessCreateSteps();

        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; } = new List<Business>();
        public IList<Business> RecycleBin { get; private set; }

        public BusinessGetByKeySteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a business key")]
        public async Task GivenIHaveABusinessKey()
        {
            createSteps.GivenANewBusinessHasBeenCreated();
            await createSteps.WhenBusinessIsInsertedViaEntityFramework();
            Sut = await _dbContext.Business.FirstAsync();
            SutKey = Sut.BusinessKey;
        }
        
        [Given(@"the key is type Guid")]
        public void GivenTheKeyIsTypeGuid()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }        
        
        [When(@"the business exists in persistence")]
        public void WhenTheBusinessExistsInPersistence()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }
        
        [When(@"Business is queried by key via Entity framework")]
        public async Task WhenBusinessIsQueriedByKeyViaEntityFramework()
        {
            Sut = await _dbContext.Business.FirstAsync(x => x.BusinessKey == SutKey);
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }
        
        [Then(@"the matching business is returned")]
        public void ThenTheMatchingBusinessIsReturned()
        {
            Assert.IsTrue(Sut.BusinessKey == SutKey);
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
