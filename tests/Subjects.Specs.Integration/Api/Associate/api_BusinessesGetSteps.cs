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
    public class Api_BusinessesGetSteps : ICrudSteps<Business>
    {
        private readonly IConfiguration _config;
        private readonly Api_BusinessCreateSteps createSteps = new Api_BusinessCreateSteps();

        public IList<Business> Suts { get; private set; } = new List<Business>();
        public Business Sut { get; private set; }
        public Guid SutKey { get; private set; }
        public IList<Business> RecycleBin { get; set; }

        public Api_BusinessesGetSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
        }

        [Given(@"I request the list of businesses from the Web API")]
        public async Task GivenIRequestTheListOfBusinessesFromTheWebAPI()
        {
            createSteps.GivenIHaveANewBusinessForTheWebAPI();
            await createSteps.WhenBusinessIsCreatedViaWebAPI();
            Suts = createSteps.Suts;
            Sut = createSteps.Sut;
            SutKey = createSteps.SutKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Businesses are queried via Web API")]
        public async Task WhenBusinessesAreQueriedViaWebAPI()
        {
            var client = new HttpClientFactory().CreateJsonClient<Business>();
            var response = await client.GetAsync(new WebApiUrlFactory(_config, "Subjects", "Business").CreateGetAllUrl());
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts = JsonConvert.DeserializeObject<List<Business>>(result).Take(5).ToList();
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
        }

        [Then(@"All persisted businesses are returned from the Web API")]
        public void ThenAllPersistedBusinessesAreReturnedFromTheWebAPI()
        {
            Assert.IsTrue(Suts.Any());
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await createSteps.Cleanup();
        }
    }
}
