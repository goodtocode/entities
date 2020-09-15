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
    public class Fn_BusinessesGetSteps : ICrudSteps<Business>
    {
        private readonly IConfiguration _config;
        private readonly Fn_BusinessCreateSteps createSteps = new Fn_BusinessCreateSteps();

        public IList<Business> Suts { get; private set; } = new List<Business>();
        public Business Sut { get; private set; }
        public Guid SutKey { get; private set; }
        public IList<Business> RecycleBin { get; set; }

        public Fn_BusinessesGetSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs.Integration")).Create();
        }

        [Given(@"I request the list of businesses from the Azure Function")]
        public async Task GivenIRequestTheListOfBusinessesFromTheAzureFunction()
        {
            await createSteps.WhenBusinessIsCreatedViaAzureFunction();
        }

        [When(@"Businesses are queried via Azure Function")]
        public async Task WhenBusinessesAreQueriedViaAzureFunction()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.GetAsync(new AzureFunctionUrlFactory(_config, "Subjects", "Business").CreateGetAllUrl());
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts = JsonConvert.DeserializeObject<List<Business>>(result).Take(5).ToList();
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
        }

        [Then(@"All persisted businesses are returned from the Azure Function")]
        public void ThenAllPersistedBusinessesAreReturnedFromTheAzureFunction()
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
