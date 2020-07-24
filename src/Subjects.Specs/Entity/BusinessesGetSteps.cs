using GoodToCode.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessesGetSteps
    {
        private Guid _sutKey;
        private Business _sut;
        private EntityDataContext _context;
        private string _connectionString;
        private IConfiguration _config;

        private Uri businessGetFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessGet?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={_sutKey}"); } }
        private Uri businessesGetFunctionsUrl { get { return new Uri("https://subject-functions.azurewebsites.net/api/BusinessesGet?code=Vi0CYsNfYvLrDMy6D0hiX9ZqpO5ORX/wsN5uqK2qzgjzORaSNTEfGQ=="); } }
        private Uri businessSaveFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessSave?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={_sutKey}"); } }

        public BusinessesGetSteps()
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

        [Given(@"I request the list of businesses")]
        public void GivenIRequestTheListOfBusinesses()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Businesses are queried via Azure Function")]
        public void WhenBusinessesAreQueriedViaAzureFunction()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Businesses are queried via Entity framework")]
        public void WhenBusinessesAreQueriedViaEntityFramework()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"All persisted businesses are returned")]
        public void ThenAllPersistedBusinessesAreReturned()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
