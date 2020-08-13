using GoodToCode.Shared.Domain;
using GoodToCode.Subjects.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
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
    public class BusinessQuerySteps
    {        
        private readonly SubjectsDbContext _context;
        private readonly string _connectionString;
        private readonly IConfiguration _config;

        private Guid SutKey { get; set; }
        private List<Business> Sut { get; set; }

        public BusinessQuerySteps()
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

        [Given(@"I have a business key that can be Queried")]
        public async Task GivenIHaveABusinessKeyThatCanBeQueried()
        {
            var item = await _context.Business.FirstAsync();
            SutKey = item.BusinessKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Business is read by key via Query")]
        public void WhenBusinessIsReadByKeyViaQuery()
        {
            var query = new BusinessGetQuery(SutKey);
            var handle = new BusinessGetQuery.Handler(_context);
            //Sut = handle.Handle(query, new System.Threading.CancellationToken()).Result;
        }

        [When(@"the business exists in Query")]
        public void WhenTheBusinessExistsInQuery()
        {
            Assert.IsFalse(Sut == null);
        }

        [Then(@"the matching business is returned from the Query")]
        public void ThenTheMatchingBusinessIsReturnedFromTheQuery()
        {
            Assert.IsTrue(Sut.Any(x => x.BusinessKey == SutKey));
        }
    }
}
