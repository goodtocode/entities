using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class Api_BusinessGetByKeySteps : ICrudSteps<Business>
    {        
        private readonly IConfiguration _config;
        private readonly Api_BusinessCreateSteps createSteps = new Api_BusinessCreateSteps();
        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; }
        public IList<Business> RecycleBin { get; private set; }

        public Api_BusinessGetByKeySteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs.Integration")).Create();
        }

        [Given(@"I have a business key to get from the Web API")]
        public async Task GivenIHaveABusinessKeyToGetFromTheWebAPI()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.GetAsync(new WebApiUrlFactory(_config, "Subjects", "Business").CreateGetAllUrl());
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts = JsonConvert.DeserializeObject<List<Business>>(result).Take(1).ToList();
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
        }

        [When(@"Business is queried by key via Web API")]
        public async Task WhenBusinessIsQueriedByKeyViaWebAPI()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.GetAsync(new WebApiUrlFactory(_config, "Subjects", "Business").CreateGetByKeyUrl(SutKey));
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
        }

        [Then(@"the matching business is returned from the Web API")]
        public void ThenTheMatchingBusinessIsReturnedFromTheWebAPI()
        {
            Assert.IsTrue(Sut.BusinessKey == SutKey);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await createSteps.Cleanup();
        }
    }
}
