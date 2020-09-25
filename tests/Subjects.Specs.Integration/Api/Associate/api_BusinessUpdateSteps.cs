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
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using TechTalk.SpecRun.Common.Helper;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class Api_BusinessUpdateSteps : ICrudSteps<Business>
    {
        private readonly IConfiguration _config;
        private readonly Api_BusinessCreateSteps createSteps = new Api_BusinessCreateSteps();
        private string _originalValue = string.Empty;
        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; } = new List<Business>();
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public Api_BusinessUpdateSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs.Integration")).Create();
        }

        [Given(@"I have an non empty business key for the Web API")]
        public async Task GivenIHaveAnNonEmptyBusinessKeyForTheWebAPI()
        {
            createSteps.GivenIHaveANewBusinessForTheWebAPI();
            await createSteps.WhenBusinessIsCreatedViaWebAPI();
            Suts = createSteps.Suts;
            Sut = createSteps.Sut;
            SutKey = createSteps.SutKey;
            _originalValue = Sut.BusinessName;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [Given(@"the business name is provided for the Web API")]
        public void GivenTheBusinessNameIsProvidedForTheWebAPI()
        {
            Sut.BusinessName = $"BusinessUpdateSteps Test {Guid.NewGuid()}";
            Assert.IsTrue(Sut.BusinessName.IsNotNullOrWhiteSpace());
            Assert.IsTrue(Sut.BusinessName != _originalValue);
        }

        [When(@"Business is posted via Web API")]
        public async Task WhenBusinessIsPostedViaWebAPI()
        {
            var client = new HttpClientFactory().CreateJsonClient<Business>();
            var url = new WebApiUrlFactory(_config, "Subjects", "Business").CreateUpdateUrl(SutKey);
            var response = await client.PutAsync(url, new StringContent(JsonConvert.SerializeObject(Sut), Encoding.UTF8, "application/json"));
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [Then(@"the business is updated in persistence when queried from Web API")]
        public async Task ThenTheBusinessIsUpdatedInPersistenceWhenQueriedFromWebAPI()
        {
            var client = new HttpClientFactory().CreateJsonClient<Business>();
            var response = await client.GetAsync(new WebApiUrlFactory(_config, "Subjects", "Business").CreateGetByKeyUrl(SutKey));
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            Assert.IsTrue(SutKey != Guid.Empty);
            Assert.IsTrue(Sut.BusinessName != _originalValue);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await createSteps.Cleanup();
        }
    }
}
