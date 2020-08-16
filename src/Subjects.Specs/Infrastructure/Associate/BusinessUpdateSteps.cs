using GoodToCode.Shared.Specs;
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
    public class BusinessUpdateSteps
    {
        private readonly SubjectsDbContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private string SutName { get; set; }
        private string SutNameNew { get; set; }
        private Business Sut { get; set; }

        public BusinessUpdateSteps()
        {
            _config = new ConfigurationFactory("Subjects.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _context = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An existing Business has been queried")]
        public async Task GivenAnExistingBusinessHasBeenQueried()
        {
            Sut = await _context.Business.Take(1).FirstOrDefaultAsync();
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
            _context.Entry(Sut).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the existing business can be queried by key")]
        public async Task ThenTheExistingBusinessCanBeQueriedByKey()
        {
            Sut = await _context.Business.FirstOrDefaultAsync(x => x.BusinessKey == SutKey);
        }

        [Then(@"the Business name matches the new name")]
        public void ThenTheBusinessNameMatchesTheNewName()
        {
            Assert.IsTrue(SutNameNew == Sut.BusinessName);
            Assert.IsFalse(SutNameNew == SutName);
        }

    }
}
