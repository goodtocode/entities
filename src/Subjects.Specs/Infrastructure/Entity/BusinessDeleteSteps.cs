using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects.Infrastructure.Entity
{
    [Binding]
    public class BusinessDeleteSteps
    {
        private readonly SubjectsDbContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private Business Sut { get; set; }
        private Uri BusinessGetFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessGet?code=9AVbUx74MCU6k4wAXyO6NxEJy3SdWJMXAMwHQzm99LWB7RcVAF/1HQ==&key={SutKey}"); } }
        private Uri BusinessSaveFunctionsUrl { get { return new Uri($"https://subject-functions.azurewebsites.net/api/BusinessSave?code=T3KPnhwNI1Ca67SbbXSvdHUIX3PhXc5uxjbFC0nKBGcahBfyEziHvQ==&key={SutKey}"); } }

        public BusinessDeleteSteps()
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

        [Given(@"An Business has been queried to be deleted")]
        public async Task GivenAnBusinessHasBeenQueriedToBeDeleted()
        {
            Sut = await _context.Business.Take(1).FirstOrDefaultAsync();
            SutKey = Sut.BusinessKey;
        }

        [Given(@"a business to be deleted was found in persistence")]
        public void GivenABusinessToBeDeletedWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.BusinessKey != Guid.Empty);
        }

        [When(@"the Business is Deleted via Entity Framework")]
        public async Task WhenTheBusinessIsDeletedViaEntityFramework()
        {
            _context.Entry(Sut).State = EntityState.Deleted;
            var result = await _context.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the deleted business is queried by key")]
        public async Task ThenTheDeletedBusinessIsQueriedByKey()
        {
            Sut = await _context.Business.FirstOrDefaultAsync(x => x.BusinessKey == SutKey);
        }

        [Then(@"the Business is not found")]
        public void ThenTheBusinessIsNotFound()
        {
            Assert.IsTrue(Sut?.BusinessKey != SutKey);
        }


    }
}
