using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessCreateSteps : ICrudSteps<Business>
    {
        private readonly SubjectsDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private int _rowsAffected;

        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> RecycleBin { get; private set; } = new List<Business>();

        public BusinessCreateSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs")).Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }
        private Uri BusinessesGetFunctionsUrl { get { return new Uri("https://subject-functions.azurewebsites.net/api/BusinessesGet?code=Vi0CYsNfYvLrDMy6D0hiX9ZqpO5ORX/wsN5uqK2qzgjzORaSNTEfGQ=="); } }


        [Given(@"I request the list of businesses from Web API")]
        public void GivenIRequestTheListOfBusinessesFromWebAPI()
        {
            ScenarioContext.Current.Pending();
        }

        [When(@"Businesses are Get via Web API")]
        public void WhenBusinessesAreGetViaWebAPI()
        {
            ScenarioContext.Current.Pending();
        }

        [Then(@"All persisted businesses are returned from Web API")]
        public void ThenAllPersistedBusinessesAreReturnedFromWebAPI()
        {
            ScenarioContext.Current.Pending();
        }



        [Given(@"I request the list of businesses")]
        public void GivenIRequestTheListOfBusinesses()
        {
            Sut = new List<Business>();
        }

        [When(@"Businesses are queried via Azure Function")]
        public async Task WhenBusinessesAreQueriedViaAzureFunction()
        {
            var client = new HttpClient();
            var response = await client.GetAsync(BusinessesGetFunctionsUrl);
            var result = await response.Content.ReadAsStringAsync();
            Sut = JsonSerializer.Deserialize<List<Business>>(result);
        }

        [Then(@"All persisted businesses are returned")]
        public void ThenAllPersistedBusinessesAreReturned()
        {
            Assert.IsTrue(Sut.Any());
        }
    }
}
