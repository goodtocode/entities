using GoodToCode.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessGetByKeySteps
    {
        private Guid _sutKey;
        private Business _sut;
        private EntityDataContext _context;
        private string _connectionString;
        private IConfiguration _config;        
        
        private Uri businessGetFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessGet?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={_sutKey}"); } }
        private Uri businessesGetFunctionsUrl { get { return new Uri("https://subject-functions.azurewebsites.net/api/BusinessesGet?code=Vi0CYsNfYvLrDMy6D0hiX9ZqpO5ORX/wsN5uqK2qzgjzORaSNTEfGQ=="); } }
        private Uri businessSaveFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessSave?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={_sutKey}"); } }

        public BusinessGetByKeySteps()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs"))
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
            _connectionString = _config.GetConnectionString("DefaultConnection");
            //_connectionString = "Server=tcp:GoodToCode.database.windows.net,1433;Initial Catalog=EntityData;user id=TestUser; password=57595709-9E9C-47EA-ABBF-4F3BAA1B0D37;Persist Security Info=False;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;Application Name=GoodToCodeEntities;";
            var options = new DbContextOptionsBuilder<EntityDataContext>();
            options.UseSqlServer(_connectionString);
            _context = new EntityDataContext(options.Options);
        }

        [Given(@"I have a business key")]
        public async Task GivenIHaveABusinessKey()
        {
            var item = await _context.Business.FirstAsync();
            _sutKey = item.BusinessKey;
        }
        
        [Given(@"the key is type Guid")]
        public void GivenTheKeyIsTypeGuid()
        {
            Assert.IsTrue(_sutKey is Guid);
        }
        
        [When(@"Business is queried by key via Azure Function")]
        public async Task WhenBusinessIsQueriedByKeyViaAzureFunction()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(businessGetFunctionsUrl);
            var result = await response.Content.ReadAsStringAsync();
            _sut = JsonSerializer.Deserialize<Business>(result);
        }
        
        [When(@"the business exists in persistence")]
        public void WhenTheBusinessExistsInPersistence()
        {
            Assert.IsTrue(_sutKey != Guid.Empty);
        }
        
        [When(@"Business is queried by key via Entity framework")]
        public async Task WhenBusinessIsQueriedByKeyViaEntityFramework()
        {
            _sut = await _context.Business.FirstAsync(x => x.BusinessKey == _sutKey);
            Assert.IsTrue(_sut.BusinessKey != Guid.Empty);
        }
        
        [Then(@"the matching business is returned")]
        public void ThenTheMatchingBusinessIsReturned()
        {
            Assert.IsTrue(_sut.BusinessKey == _sutKey);
        }
    }
}
