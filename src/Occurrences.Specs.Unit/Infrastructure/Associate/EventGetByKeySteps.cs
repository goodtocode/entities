using GoodToCode.Shared.Specs;
using GoodToCode.Occurrences.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using GoodToCode.Occurrences.Infrastructure;
using System.Collections.Generic;
using System.IO;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventGetByKeySteps : ICrudSteps<Event>
    {        
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly EventCreateSteps createSteps = new EventCreateSteps();

        public Event Sut { get; set; }
        public IList<Event> Suts { get; set; }
        public Guid SutKey { get; set; }
        public IList<Event> RecycleBin { get; set; } = new List<Event>();

        public EventGetByKeySteps()
        {
            _config = new ConfigurationFactory(Directory.GetCurrentDirectory().Replace("TestResults", "Occurrences.Specs.Unit")).Create();
            _connectionString = new ConnectionStringFactory(_config).Create();
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"I have a Event key")]
        public async Task GivenIHaveAEventKey()
        {
            createSteps.GivenANewEventHasBeenCreated();
            await createSteps.WhenEventIsInsertedViaEntityFramework();
            Sut = await _dbContext.Event.FirstAsync();
            SutKey = Sut.EventKey;
        }
        
        [Given(@"the key is type Guid")]
        public void GivenTheKeyIsTypeGuid()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }        
        
        [When(@"the Event exists in persistence")]
        public void WhenTheEventExistsInPersistence()
        {
            Assert.IsTrue(SutKey != Guid.Empty);
        }
        
        [When(@"Event is queried by key via Entity framework")]
        public async Task WhenEventIsQueriedByKeyViaEntityFramework()
        {
            Sut = await _dbContext.Event.FirstAsync(x => x.EventKey == SutKey);
            Assert.IsTrue(Sut.EventKey != Guid.Empty);
        }
        
        [Then(@"the matching Event is returned")]
        public void ThenTheMatchingEventIsReturned()
        {
            Assert.IsTrue(Sut.EventKey == SutKey);
        }

        [TestCleanup]
        public async Task Cleanup()
        {
            foreach (var item in RecycleBin)
            {
                _dbContext.Entry(item).State = EntityState.Deleted;
                await _dbContext.SaveChangesAsync();
            }
            await createSteps.Cleanup();
        }
    }
}
