using GoodToCode.Occurrences.Application;
using GoodToCode.Occurrences.Infrastructure;
using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventQuerySteps : IQuerySteps<Event>
    {        
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly EventSaveCommandSteps commandSteps = new EventSaveCommandSteps();

        public Guid SutKey { get; private set; }
        public IList<Event> Sut { get; private set; }
        public IList<Event> RecycleBin { get; private set; } = new List<Event>();

        public EventQuerySteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a Event key that can be Queried")]
        public async Task GivenIHaveAEventKeyThatCanBeQueried()
        {
            commandSteps.GivenANewEventSaveCommandHasBeenCreated();
            await commandSteps.WhenTheEventIsInsertedViaCQRSCommand();
            Sut = await _dbContext.Event.Take(10).ToListAsync();
            SutKey = Sut.FirstOrDefault().EventKey;
            Assert.IsTrue(SutKey != Guid.Empty);
        }

        [When(@"Event is read by key via Query")]
        public async Task WhenEventIsReadByKeyViaQueryAsync()
        {
            var query = new EventGetQuery(SutKey);
            var handle = new EventGetHandler(_dbContext);
            var response = await handle.Handle(query, new System.Threading.CancellationToken());
            Sut = response.Result;
        }

        [When(@"the Event exists in Query")]
        public void WhenTheEventExistsInQuery()
        {
            Assert.IsFalse(Sut == null);
        }

        [Then(@"the matching Event is returned from the Query")]
        public void ThenTheMatchingEventIsReturnedFromTheQuery()
        {
            Assert.IsTrue(Sut.Any(x => x.EventKey == SutKey));
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            foreach (var item in RecycleBin)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
        }
    }
}
