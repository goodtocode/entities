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
    public class Api_BusinessCreateSteps : ICrudSteps<Business>
    {
        private readonly IConfiguration _config;

        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; } = new List<Business>();
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public Api_BusinessCreateSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs.Integration")).Create();
        }

        [Given(@"I have a new business for the Web API")]
        public void GivenIHaveANewBusinessForTheWebAPI()
        {
            Sut = new Business() { BusinessName = "BusinessInsertSteps Test" };
        }

        [When(@"Business is created via Web API")]
        public async Task WhenBusinessIsCreatedViaWebAPI()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.PutAsync(new WebApiUrlFactory(_config, "Subjects", "Business").CreateCreateUrl(), new StringContent(JsonConvert.SerializeObject(Sut)));
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();            
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            RecycleBin.Add(Sut);
        }

        [Then(@"the business is inserted to persistence from the Web API")]
        public async Task ThenTheBusinessIsInsertedToPersistenceFromTheWebAPI()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.GetAsync(new WebApiUrlFactory(_config, "Subjects", "Business").CreateGetByKeyUrl(SutKey));
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            Assert.IsFalse(SutKey != Guid.Empty);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            var client = new HttpClientFactory().Create();
            
            foreach (var item in RecycleBin)
            {
                await client.DeleteAsync(new WebApiUrlFactory(_config, "Subjects", "Business").CreateDeleteUrl(item.RowKey));
            }
        }
    }
}
