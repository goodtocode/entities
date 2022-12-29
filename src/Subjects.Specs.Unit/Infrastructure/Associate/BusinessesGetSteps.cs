using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Infrastructure;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessesGetSteps : ICrudSteps<Business>
    {
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly BusinessCreateSteps createSteps = new BusinessCreateSteps();

        public Business Sut { get; private set; } = new();
        public IList<Business> Suts { get; private set; } = new List<Business>();
        public Guid SutKey { get; private set; }
        public IList<Business> RecycleBin { get; set; } = new List<Business>();

        public BusinessesGetSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I request the list of businesses")]
        public async Task GivenIRequestTheListOfBusinesses()
        {
            createSteps.GivenANewBusinessHasBeenCreated();
            await createSteps.WhenBusinessIsInsertedViaEntityFramework();
            Sut = await _dbContext.Business.FirstAsync();
            SutKey = Sut.BusinessKey;
        }

        [When(@"Businesses are queried via Entity framework")]
        public async Task WhenBusinessesAreQueriedViaEntityFrameworkAsync()
        {
            Suts = await _dbContext.Business.Take(10).ToListAsync();
            Sut = Suts?.FirstOrDefault() ?? new Business();
            SutKey = Sut?.BusinessKey ?? Guid.Empty;
        }

        [Then(@"All persisted businesses are returned")]
        public void ThenAllPersistedBusinessesAreReturned()
        {
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
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
