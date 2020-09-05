using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class api_BusinessCreateSteps : ICrudSteps<Business>
    {
        private readonly IConfiguration _config;

        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; }
        public IList<Business> RecycleBin { get; private set; }

        public api_BusinessCreateSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs")).Create();
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
            var client = new HttpClientFactory().Create();
            var response = await client.PutAsync(new AzureFunctionUrlFactory("Subjects", "Business").CreateCreateUrl(), new StringContent(JsonConvert.SerializeObject(Sut)));
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            RecycleBin.Add(Sut);
        }
        
        [When(@"the business does not exist in persistence")]
        public async Task WhenTheBusinessDoesNotExistInPersistence()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.GetAsync(new AzureFunctionUrlFactory("Subjects", "Business").CreateGetByKeyUrl(SutKey));
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            Assert.IsFalse(SutKey != Guid.Empty);
        }
                
        [Then(@"the business is inserted to persistence")]
        public void ThenTheBusinessIsInsertedToPersistence()
        {
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            var client = new HttpClientFactory().Create();
            
            foreach (var item in RecycleBin)
            {
                await client.DeleteAsync(new AzureFunctionUrlFactory("Subjects", "Business").CreateDeleteUrl(item.RowKey));
            }
        }
    }
}
