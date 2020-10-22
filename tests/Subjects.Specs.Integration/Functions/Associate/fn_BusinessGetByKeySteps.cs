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
    public class Fn_BusinessGetByKeySteps
    {
        
        private readonly IConfiguration _config;
        private readonly Fn_BusinessCreateSteps createSteps = new Fn_BusinessCreateSteps();
        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; } = new List<Business>();
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public Fn_BusinessGetByKeySteps()
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

        [Given(@"I have a business key to get from the Azure Function")]
        public async Task GivenIHaveABusinessKeyToGetFromTheAzureFunction()
        {
            createSteps.GivenIHaveANewBusinessForTheAzureFunction();
            await createSteps.WhenBusinessIsCreatedViaAzureFunction();
            Suts = createSteps.Suts;
            Sut = createSteps.Sut;
            SutKey = createSteps.SutKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Business is queried by key via Azure Function")]
        public async Task WhenBusinessIsQueriedByKeyViaAzureFunction()
        {
            var client = new HttpClientJson<Business>();
            var response = await client.GetAsync(new Uri($"{_config["Stack:Subjects:FunctionsUrl"]}/api/BusinessGet?code={_config["Stack:Subjects:FunctionsCode"]}&key={SutKey}"));
            Assert.IsTrue(response.IsSuccessStatusCode);
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
        }

        [Then(@"the matching business is returned from the Azure Function")]
        public void ThenTheMatchingBusinessIsReturnedFromTheAzureFunction()
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
