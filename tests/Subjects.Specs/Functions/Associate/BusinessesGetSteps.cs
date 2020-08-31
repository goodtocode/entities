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
    public class BusinessesGetSteps
    {
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private List<Business> Sut { get; set; }
        private Uri BusinessesGetFunctionsUrl { get { return new Uri("https://subject-functions.azurewebsites.net/api/BusinessesGet?code=Vi0CYsNfYvLrDMy6D0hiX9ZqpO5ORX/wsN5uqK2qzgjzORaSNTEfGQ=="); } }

        public BusinessesGetSteps()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs"))
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
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
