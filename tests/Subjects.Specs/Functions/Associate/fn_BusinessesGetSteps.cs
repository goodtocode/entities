using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class api_BusinessesGetSteps : ICrudSteps<Business>
    {
        private readonly IConfiguration _config;
        private readonly api_BusinessCreateSteps createSteps = new api_BusinessCreateSteps();

        public List<Business> Suts { get; private set; }
        public Business Sut { get; private set; }
        public Guid SutKey { get; private set; }
        public IList<Business> RecycleBin { get; set; }
        public Uri Url { get; }

        public api_BusinessesGetSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs")).Create();
            Url = new Uri($"{_config.GetValue<string>("Functions:Subjects")}/api/BusinessesGet?code=Vi0CYsNfYvLrDMy6D0hiX9ZqpO5ORX/wsN5uqK2qzgjzORaSNTEfGQ=");
        }        

        [Given(@"I request the list of businesses")]
        public void GivenIRequestTheListOfBusinesses()
        {
            createSteps.GivenANewBusinessHasBeenCreated();
            await createSteps.WhenBusinessIsInsertedViaEntityFramework();
            var client = new HttpClientFactory().Create();
            client.GetAsync()
            Sut = await _dbContext.Business.FirstAsync();
            SutKey = Sut.BusinessKey;
        }

        [When(@"Businesses are queried via Azure Function")]
        public async Task WhenBusinessesAreQueriedViaAzureFunction()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.GetAsync(Url);
            var result = await response.Content.ReadAsStringAsync();
            Suts = JsonSerializer.Deserialize<List<Business>>(result).FirstOrDefault();
        }

        [Then(@"All persisted businesses are returned")]
        public void ThenAllPersistedBusinessesAreReturned()
        {
            Assert.IsTrue(Suts.Any());
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            foreach (var item in RecycleBin)
            {
                
            }
            await createSteps.Cleanup();
        }
    }
}
