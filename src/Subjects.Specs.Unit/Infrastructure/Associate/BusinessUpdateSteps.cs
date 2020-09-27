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
    public class BusinessUpdateSteps : ICrudSteps<Business>
    {
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly BusinessCreateSteps createSteps = new BusinessCreateSteps();
        
        private string SutName { get; set; }
        private string SutNameNew { get; set; }

        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; } = new List<Business>();
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public BusinessUpdateSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An existing Business has been queried")]
        public async Task GivenAnExistingBusinessHasBeenQueried()
        {
            createSteps.GivenANewBusinessHasBeenCreated();
            await createSteps.WhenBusinessIsInsertedViaEntityFramework();
            Sut = await _dbContext.Business.FirstAsync();
            SutKey = Sut.BusinessKey;
        }

        [Given(@"a business was found in persistence")]
        public void GivenABusinessWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }

        [When(@"the Business name changes")]
        public void WhenTheBusinessNameChanges()
        {
            SutKey = Sut.BusinessKey;
            SutName = Sut.BusinessName;
            SutNameNew = $"Business name as of {DateTime.UtcNow.ToShortTimeString()}";
            Sut.BusinessName = SutNameNew;
        }

        [When(@"Business is Updated via Entity Framework")]
        public async Task WhenBusinessIsUpdatedViaEntityFramework()
        {
            _dbContext.Entry(Sut).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the existing business can be queried by key")]
        public async Task ThenTheExistingBusinessCanBeQueriedByKey()
        {
            Sut = await _dbContext.Business.FirstOrDefaultAsync(x => x.BusinessKey == SutKey);
        }

        [Then(@"the Business name matches the new name")]
        public void ThenTheBusinessNameMatchesTheNewName()
        {
            Assert.IsTrue(SutNameNew == Sut.BusinessName);
            Assert.IsFalse(SutNameNew == SutName);
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
