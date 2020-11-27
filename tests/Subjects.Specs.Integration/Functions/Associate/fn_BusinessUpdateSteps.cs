using GoodToCode.Shared.Extensions;
using GoodToCode.Subjects.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.AzureAppConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class Fn_BusinessUpdateSteps
    {
        private readonly IConfiguration _config;
        private readonly Fn_BusinessCreateSteps createSteps = new Fn_BusinessCreateSteps();
        private string _originalValue = string.Empty;
        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; } = new List<Business>();
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public Fn_BusinessUpdateSteps()
        {
            var builder = new ConfigurationBuilder();
            builder.AddAzureAppConfiguration(options =>
                    options
                        .Connect(Environment.GetEnvironmentVariable("AppSettingsConnection"))
                        .ConfigureRefresh(refresh =>
                        {
                            refresh.Register("Stack:Shared:Sentinel", refreshAll: true)
                                    .SetCacheExpiration(new TimeSpan(0, 60, 0));
                        })
                        .Select(KeyFilter.Any, LabelFilter.Null)
                        .Select(KeyFilter.Any, Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Production")
                    );
            _config = builder.Build();
        }

        [Given(@"I have an non empty business key for the Azure Function")]
        public async Task GivenIHaveAnNonEmptyBusinessKeyForTheAzureFunction()
        {
            createSteps.GivenIHaveANewBusinessForTheAzureFunction();
            await createSteps.WhenBusinessIsCreatedViaAzureFunction();
            Suts = createSteps.Suts;
            Sut = createSteps.Sut;
            SutKey = createSteps.SutKey;
            _originalValue = Sut.BusinessName;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [Given(@"the business name is provided for the Azure Function")]
        public void GivenTheBusinessNameIsProvidedForTheAzureFunction()
        {
            Assert.IsTrue(_originalValue.Length > 0);
        }

        [When(@"Business is posted via Azure Function")]
        public async Task WhenBusinessIsPostedViaAzureFunction()
        {
            var client = new HttpClientJson<Business>();
            var response = await client.PutAsync(new Uri($"{_config["Stack:Subjects:FunctionsUrl"]}/api/BusinessUpdate?code={_config["Stack:Subjects:FunctionsCode"]}&key={SutKey}"), new StringContent(JsonConvert.SerializeObject(Sut), Encoding.UTF8, "application/json"));
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            RecycleBin.Add(Sut);
        }

        [Then(@"the business is updated in persistence when queried from Azure Function")]
        public async Task ThenTheBusinessIsUpdatedInPersistenceWhenQueriedFromAzureFunction()
        {
            var client = new HttpClientJson<Business>();
            var response = await client.GetAsync(new Uri($"{_config["Stack:Subjects:FunctionsUrl"]}/api/BusinessGet?code={_config["Stack:Subjects:FunctionsCode"]}&key={SutKey}"));
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await createSteps.Cleanup();
        }
    }
}
