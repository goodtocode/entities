using GoodToCode.Shared.Specs;
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
    public class api_BusinessGetByKeySteps : ICrudSteps<Business>
    {        
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Business Sut { get; set; }
        private Uri BusinessGetFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessGet?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={SutKey}"); } }

        public api_BusinessGetByKeySteps()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs"))
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
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
            Assert.IsTrue(SutKey is Guid);
        }
        
        [When(@"Business is queried by key via Azure Function")]
        public async Task WhenBusinessIsQueriedByKeyViaAzureFunction()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(BusinessGetFunctionsUrl);
            var result = await response.Content.ReadAsStringAsync();
            Sut = JsonConvert.DeserializeObject<Business>(result);
        }
        
        [When(@"the business exists in persistence")]
        public void WhenTheBusinessExistsInPersistence()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }
        
        [Then(@"the matching business is returned")]
        public void ThenTheMatchingBusinessIsReturned()
        {
            Assert.IsTrue(Sut.BusinessKey == SutKey);
        }
    }
}
