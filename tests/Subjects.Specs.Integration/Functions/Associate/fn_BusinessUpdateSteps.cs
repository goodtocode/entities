﻿using GoodToCode.Shared.Specs;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class fn_BusinessUpdateSteps : ICrudSteps<Business>
    {
        private readonly IConfiguration _config;
        private readonly fn_BusinessCreateSteps createSteps = new fn_BusinessCreateSteps();
        public Guid SutKey { get; private set; }
        public Business Sut { get; private set; }
        public IList<Business> Suts { get; private set; }
        public IList<Business> RecycleBin { get; private set; }

        public fn_BusinessUpdateSteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs.Integration")).Create();
        }

        [Given(@"I have an non empty business key for the Azure Function")]
        public async Task GivenIHaveAnNonEmptyBusinessKeyForTheAzureFunction()
        {
            await createSteps.WhenBusinessIsCreatedViaAzureFunction();
        }

        [Given(@"the business name is provided for the Azure Function")]
        public void GivenTheBusinessNameIsProvidedForTheAzureFunction()
        {
            Sut = new Business() { BusinessName = "BusinessUpdateSteps Test" };
        }

        [When(@"Business is posted via Azure Function")]
        public async Task WhenBusinessIsPostedViaAzureFunction()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.PostAsync(new AzureFunctionUrlFactory("Subjects", "Business").CreateUpdateUrl(SutKey), new StringContent(JsonConvert.SerializeObject(Sut)));
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            RecycleBin.Add(Sut);
        }

        [Then(@"the business is updated in persistence when queried from Azure Function")]
        public async Task ThenTheBusinessIsUpdatedInPersistenceWhenQueriedFromAzureFunction()
        {
            var client = new HttpClientFactory().Create();
            var response = await client.GetAsync(new AzureFunctionUrlFactory("Subjects", "Business").CreateGetByKeyUrl(SutKey));
            var result = await response.Content.ReadAsStringAsync();
            Suts.Add(JsonConvert.DeserializeObject<Business>(result));
            Sut = Suts.FirstOrDefault();
            SutKey = Sut.BusinessKey;
            Assert.IsFalse(SutKey != Guid.Empty);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            await createSteps.Cleanup();
        }
    }
}