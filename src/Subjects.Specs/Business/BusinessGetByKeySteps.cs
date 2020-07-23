using GoodToCode.Shared.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Subjects
{
    [Binding]
    public class BusinessGetByKeySteps
    {
        private Guid _sut = Guid.Empty;
        private EntityDataContext _context;
        private IConfiguration _config;

        public BusinessGetByKeySteps()
        {
            _config = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory().Replace("TestResults", "Subjects.Specs"))
              .AddJsonFile($"appsettings.{(Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT ") ?? "Development")}.json")
              .AddJsonFile("appsettings.json")
              .Build();
            var options = new DbContextOptionsBuilder<EntityDataContext>();
                options.UseSqlServer(_config.GetConnectionString("DefaultConnection"));
            _context = new EntityDataContext(options.Options);
        }

        [Given(@"I have a business key")]
        public void GivenIHaveABusinessKey()
        {
            _sut = new Guid();
        }

        [Given(@"the key is type Guid")]
        public void GivenTheKeyIsTypeGuid()
        {
            Assert.IsTrue(_sut is Guid);
        }

        [When(@"Business is queried by key via Azure Function")]
        public void WhenBusinessIsQueriedByKeyViaAzureFunction()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the business exists in persistence")]
        public void WhenTheBusinessExistsInPersistence()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"Business is queried by key via Entity framework")]
        public async Task WhenBusinessIsQueriedByKeyViaEntityFramework()
        {            
            var sut = await _context.Business.FirstAsync(x => x.BusinessKey == _sut);
            Assert.IsTrue(sut.BusinessKey != Guid.Empty);
        }
        
        [Then(@"the matching business is returned")]
        public void ThenTheMatchingBusinessIsReturned()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
