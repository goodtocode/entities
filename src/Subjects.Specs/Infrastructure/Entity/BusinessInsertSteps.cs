using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Shared.Specs
{
    [Binding]
    public class BusinessInsertSteps
    {
        private readonly SubjectsDbContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Business Sut { get; set; }
        private Uri BusinessGetFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessGet?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={SutKey}"); } }        
        private Uri BusinessSaveFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessSave?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={SutKey}"); } }

        public BusinessInsertSteps()
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

        [Given(@"I have an empty business key")]
        public void GivenIHaveAnEmptyBusinessKey()
        {
            SutKey = Guid.Empty;
        }
        
        [Given(@"the business name is provided")]
        public void GivenTheBusinessNameIsProvided()
        {
            Sut = new Business() { BusinessName = "BusinessInsertSteps Test" };
        }
        
        [When(@"Business is posted via Azure Function")]
        public async Task WhenBusinessIsPostedViaAzureFunction()
        {
            var client = new HttpClient();
            var response = await client.PostAsync(BusinessSaveFunctionsUrl, new StringContent(JsonConvert.SerializeObject(Sut)));
            var result = await response.Content.ReadAsStringAsync();
            Sut = JsonConvert.DeserializeObject<Business>(result);
        }
        
        [When(@"the business does not exist in persistence")]
        public async Task WhenTheBusinessDoesNotExistInPersistence()
        {
            var found = await _context.Business.Where(x => x.BusinessKey == SutKey).AnyAsync();
            Assert.IsFalse(found);
        }
        
        [When(@"Business is posted via Entity Framework")]
        public async Task WhenBusinessIsPostedViaEntityFramework()
        {            
            Sut.CreatedDate = DateTime.UtcNow;
            Sut.ModifiedDate = DateTime.UtcNow;
            Sut.TaxNumber = string.Empty;
            var entity = new Entity() { Business = Sut };
            entity.CreatedDate = DateTime.UtcNow;
            entity.ModifiedDate = DateTime.UtcNow;
            _context.Entity.Add(entity);
            var result = await _context.SaveChangesAsync();
            SutKey = Sut.BusinessKey;
            Assert.IsTrue(result > 0);
        }
        
        [Then(@"the business is inserted to persistence")]
        public async Task ThenTheBusinessIsInsertedToPersistence()
        {
            Sut = await _context.Business.FirstAsync(x => x.BusinessKey == SutKey);
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }
    }
}
