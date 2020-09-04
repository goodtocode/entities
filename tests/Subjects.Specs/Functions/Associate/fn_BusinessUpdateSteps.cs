using GoodToCode.Shared.Specs;
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

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class api_BusinessUpdateSteps : ICrudSteps<Business>
    {
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Business Sut { get; set; }
        private Uri BusinessGetFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessGet?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={SutKey}"); } }        
        private Uri BusinessSaveFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessSave?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={SutKey}"); } }

        public api_BusinessUpdateSteps()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs"))
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
        }

        [Given(@"I have an non empty business key")]
        public void GivenIHaveAnNonEmptyBusinessKey()
        {
            SutKey = Guid.Empty;
        }
        
        [Given(@"the business name is provided")]
        public void GivenTheBusinessNameIsProvided()
        {
            Sut = new Business() { BusinessName = "BusinessUpdateSteps Test" };
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
        
        [Then(@"the business is Updateed to persistence")]
        public async Task ThenTheBusinessIsUpdateedToPersistence()
        {
            Sut = await _context.Business.FirstAsync(x => x.BusinessKey == SutKey);
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }
    }
}
