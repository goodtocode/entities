using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Specs
{
    [Binding]
    public class BusinessUpdateSteps
    {
        private readonly SubjectsDbContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private string SutName { get; set; }
        private string SutNameNew { get; set; }
        private Business Sut { get; set; }
        private Uri BusinessGetFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessGet?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={SutKey}"); } }        
        private Uri BusinessSaveFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessSave?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={SutKey}"); } }

        public BusinessUpdateSteps()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs"))
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
            _connectionString = _config.GetConnectionString("DefaultConnection");
            var options = new DbContextOptionsBuilder<SubjectsDbContext>();
            options.UseSqlServer(_connectionString);
            _context = new SubjectsDbContext(options.Options);
        }

        [Given(@"An existing Business has been queried")]
        public async Task GivenAnExistingBusinessHasBeenQueried()
        {
            Sut = await _context.Business.Take(1).FirstOrDefaultAsync();
        }

        [Given(@"a business was found in persistence")]
        public void GivenABusinessWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }

        [When(@"the Business name changes")]
        public void WhenTheBusinessNameChanges()
        {
            SutKey = Sut.BusinessKey;
            SutName = Sut.BusinessName;
            SutNameNew = $"Business name as of {DateTime.UtcNow.ToShortTimeString()}";
            Sut.BusinessName = SutNameNew;
        }

        [When(@"Business is Updated via Entity Framework")]
        public async Task WhenBusinessIsUpdatedViaEntityFramework()
        {
            _context.Entry(Sut).State = EntityState.Modified;
            var result = await _context.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the existing business can be queried by key")]
        public async Task ThenTheExistingBusinessCanBeQueriedByKey()
        {
            Sut = await _context.Business.FirstOrDefaultAsync(x => x.BusinessKey == SutKey);
        }

        [Then(@"the Business name matches the new name")]
        public void ThenTheBusinessNameMatchesTheNewName()
        {
            Assert.IsTrue(SutNameNew == Sut.BusinessName);
        }

    }
}
