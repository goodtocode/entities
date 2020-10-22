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
    public class Api_BusinessGetByKeySteps
    {        
        private readonly IConfiguration _config;
        private readonly Api_BusinessCreateSteps createSteps = new Api_BusinessCreateSteps();
        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; } = new List<Business>();
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public Api_BusinessGetByKeySteps()
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

        [Given(@"I have a business key to get from the Web API")]
        public async Task GivenIHaveABusinessKeyToGetFromTheWebAPI()
        {
            createSteps.GivenIHaveANewBusinessForTheWebAPI();
            await createSteps.WhenBusinessIsCreatedViaWebAPI();
            Suts = createSteps.Suts;
            Sut = createSteps.Sut;
            SutKey = createSteps.SutKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Business is queried by key via Web API")]
        public async Task WhenBusinessIsQueriedByKeyViaWebAPI()
        {
            var client = new HttpClientJson<Business>();
            var response = await client.GetAsync(new Uri($"{_config["Stack:Subjects:ApiUrl"]}/v1/Users/{SutKey}"));
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
