using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessGetByKeySteps
    {        
        private readonly SubjectsDbContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Business Sut { get; set; }
        private Uri BusinessGetFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessGet?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={SutKey}"); } }

        public BusinessGetByKeySteps()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs"))
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
            _connectionString = _config.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
            options.UseSqlServer(_connectionString);
            _context = new SubjectsDbContext(options.Options);
        }

        [Given(@"I have a business key")]
        public async Task GivenIHaveABusinessKey()
        {
            var item = await _context.Business.FirstAsync();
            SutKey = item.BusinessKey;
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
            Sut = await _context.Business.FirstAsync(x => x.BusinessKey == SutKey);
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }
        
        [Then(@"the matching business is returned")]
        public void ThenTheMatchingBusinessIsReturned()
        {
            Assert.IsTrue(Sut.BusinessKey == SutKey);
        }
    }
}
