using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Application;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecRun.Common.Helper;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessSaveCommandSteps
    {
        private readonly SubjectsDbContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Business Sut { get; set; }

        public BusinessSaveCommandSteps()
        {
            _config = new ConfigurationFactory("Subjects.Specs").Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _context = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Business Save Command has been created")]
        public void GivenANewBusinessSaveCommandHasBeenCreated()
        {
            SutKey = Guid.NewGuid();
            Sut = new Business()
            {
                BusinessKey = SutKey,
                BusinessName = "BusinessSaveCommandSteps.cs Test",
                TaxNumber = string.Empty,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };
        }

        [Given(@"the Business Save Command validates")]
        public void GivenTheBusinessSaveCommandValidates()
        {
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
            Assert.IsFalse(Sut.BusinessName.IsNullOrWhiteSpace());
        }

        [When(@"the Business is inserted via CQRS Command")]
        public async Task WhenTheBusinessIsInsertedViaCQRSCommand()
        {
            var query = new BusinessSaveCommand(Sut);
            var handle = new BusinessSaveHandler(_context);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            Assert.IsTrue(response.Result);
        }

        [Then(@"the CQRS inserted business can be queried by key")]
        public async Task ThenTheCQRSInsertedBusinessCanBeQueriedByKey()
        {
            var found = await _context.Business.Where(x => x.BusinessKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }
    }
}