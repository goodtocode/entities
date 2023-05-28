using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Application;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;


namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessSaveCommandSteps : ICommandSteps<Business>
    {
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; } = new();
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public BusinessSaveCommandSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"A new Business Save Command has been created")]
        public void GivenANewBusinessSaveCommandHasBeenCreated()
        {
            SutKey = Guid.Empty;
            Sut = new Business()
            {
                BusinessKey = SutKey,
                BusinessName = "BusinessSaveCommandSteps.cs Test",
                TaxNumber = string.Empty
            };
        }

        [Given(@"the Business Save Command validates")]
        public void GivenTheBusinessSaveCommandValidates()
        {
            Assert.IsFalse(string.IsNullOrWhiteSpace(Sut.BusinessName));
        }

        [When(@"the Business is inserted via CQRS Command")]
        public async Task WhenTheBusinessIsInsertedViaCQRSCommand()
        {
            var query = new BusinessSaveCommand(Sut);
            var handle = new BusinessSaveHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            SutKey = response.Result.BusinessKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [Then(@"the CQRS inserted business can be queried by key")]
        public async Task ThenTheCQRSInsertedBusinessCanBeQueriedByKey()
        {
            var found = await _dbContext.Business.Where(x => x.BusinessKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
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