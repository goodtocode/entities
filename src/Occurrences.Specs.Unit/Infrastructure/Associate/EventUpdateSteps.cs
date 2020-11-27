using GoodToCode.Occurrences.Infrastructure;
using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Specs;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace GoodToCode.Occurrences.Specs
{
    [Binding]
    public class EventUpdateSteps : ICrudSteps<Event>
    {
        private readonly OccurrencesDbContext _dbContext;
        private readonly string _connectionString;
        private readonly IConfiguration _config;
        private readonly EventCreateSteps createSteps = new EventCreateSteps();
        private string SutName { get; set; }
        private string SutNameNew { get; set; }
        public Guid SutKey { get; set; }
        public Event Sut { get; private set; }
        public IList<Event> Suts { get; private set; } = new List<Event>();
        public IList<Event> RecycleBin { get; set; } = new List<Event>();

        public EventUpdateSteps()
        {
            _config = new ConfigurationFactory().CreateFromAzureSettings();
            _connectionString = new ConnectionStringFactory(_config).CreateFromAzureSettings("Stack:Shared:SqlConnection");
            _dbContext = new DbContextFactory(_connectionString).Create();
        }

        [Given(@"An existing Event has been queried")]
        public async Task GivenAnExistingEventHasBeenQueried()
        {
            createSteps.GivenANewEventHasBeenCreated();
            await createSteps.WhenEventIsInsertedViaEntityFramework();
            Sut = await _dbContext.Event.FirstAsync();
            SutKey = Sut.EventKey;
        }

        [Given(@"a Event was found in persistence")]
        public void GivenAEventWasFoundInPersistence()
        {
            Assert.IsTrue(Sut.EventKey != Guid.Empty);
        }

        [When(@"the Event name changes")]
        public void WhenTheEventNameChanges()
        {
            SutKey = Sut.EventKey;
            SutName = Sut.EventName;
            SutNameNew = $"Event name as of {DateTime.UtcNow.ToShortTimeString()}";
            Sut.EventName = SutNameNew;
        }

        [When(@"Event is Updated via Entity Framework")]
        public async Task WhenEventIsUpdatedViaEntityFramework()
        {
            _dbContext.Entry(Sut).State = EntityState.Modified;
            var result = await _dbContext.SaveChangesAsync();
            Assert.IsTrue(result > 0);
        }

        [Then(@"the existing Event can be queried by key")]
        public async Task ThenTheExistingEventCanBeQueriedByKey()
        {
            Sut = await _dbContext.Event.FirstOrDefaultAsync(x => x.EventKey == SutKey);
        }

        [Then(@"the Event name matches the new name")]
        public void ThenTheEventNameMatchesTheNewName()
        {
            Assert.IsTrue(SutNameNew == Sut.EventName);
            Assert.IsFalse(SutNameNew == SutName);
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
