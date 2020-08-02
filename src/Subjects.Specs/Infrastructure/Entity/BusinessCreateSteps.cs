using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessCreateSteps
    {
        private readonly SubjectsDbContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;

        private Guid SutKey { get; set; }
        private Business Sut { get; set; }

        public BusinessCreateSteps()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs"))
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
            _connectionString = _config.GetConnectionString("DefaultConnection");
            //_connectionString = "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=57595709-9E9C-47EA-ABBF-4F3BAA1B0D37;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
            options.UseSqlServer(_connectionString);
            _context = new SubjectsDbContext(options.Options);
        }

        [Given(@"A new Business has been created")]
        public void GivenANewBusinessHasBeenCreated()
        {
            SutKey = Guid.NewGuid();
            Sut = new Business()
            {
                BusinessKey = SutKey,
                BusinessName = "BusinessCreateSteps.cs Test",
                TaxNumber = string.Empty,
                CreatedDate = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow
            };
        }

        [Given(@"a business key has been provided")]
        public void GivenABusinessKeyHasBeenProvided()
        {
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }

        [Given(@"a business name has been provided")]
        public void GivenABusinessNameHasBeenProvided()
        {
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }

        [When(@"the Business does not exist in persistence by key")]
        public async Task WhenTheBusinessDoesNotExistInPersistenceByKey()
        {
            var found = await _context.Business.Where(x => x.BusinessKey == SutKey).AnyAsync();
            Assert.IsFalse(found);
        }

        [When(@"Business is inserted via Entity Framework")]
        public async Task WhenBusinessIsInsertedViaEntityFramework()
        {
            _context.Business.Add(Sut);
            _rowsAffected = await _context.SaveChangesAsync();
            SutKey = Sut.BusinessKey;
            Assert.IsTrue(_rowsAffected > 0);
        }

        [Then(@"the new business can be queried by key")]
        public async Task ThenTheNewBusinessCanBeQueriedByKey()
        {
            var found = await _context.Business.Where(x => x.BusinessKey == SutKey).AnyAsync();
            Assert.IsTrue(found);
        }
    }
}
