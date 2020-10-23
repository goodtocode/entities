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
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class Api_BusinessesGetSteps
    {
        private readonly IConfiguration _config;
        private readonly Api_BusinessCreateSteps createSteps = new Api_BusinessCreateSteps();

        public IList<Business> Suts { get; private set; } = new List<Business>();
        public Business Sut { get; private set; }
        public Guid SutKey { get; private set; }
        public IList<Business> RecycleBin { get; set; }

        public Api_BusinessesGetSteps()
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
            var client = new HttpClientJson<Business>();
            var response = await client.GetAsync(new Uri($"{_config["Stack:Subjects:ApiUrl"]}/v1/Businesses"));
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
