using GoodToCode.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Occurrences.Models
{
    public class EventAggregate : DomainAggregate<EventAggregate>
    {
        private readonly IOccurrencesDbContext _dbContext;
        private int _recordsAffected;

        public EventAggregate(int recordsAffected)
        {
            _recordsAffected = recordsAffected;
        }

        public EventAggregate(IOccurrencesDbContext context)
        {
            _dbContext = context;
        }

        // Event
        public async Task<int> EventSaveAsync(IEvent eventItem)
        {
            // Record in local storage

            IDomainEvent<IEvent> eventRaise;

            if (eventItem.EventKey != Guid.Empty)
            {
                _dbContext.Entry((Event)eventItem).State = EntityState.Modified;
                eventRaise = new EventUpdatedEvent(eventItem);
            }
            else
            {
                _dbContext.Event.Add((Event)eventItem);
                eventRaise = new EventCreatedEvent(eventItem);
            }
            _recordsAffected = await _dbContext.SaveChangesAsync();            
            eventItem.RaiseDomainEvent(eventRaise);

            return _recordsAffected;
        }
        public async Task<int> EventDeleteAsync(IEvent eventItem)
        {
            // Record in local storage

            IDomainEvent<IEvent> eventRaise;

            if (eventItem.EventKey != Guid.Empty)
            {
                _dbContext.Entry((Event)eventItem).State = EntityState.Deleted;
                eventRaise = new EventUpdatedEvent(eventItem);
            }
            else
            {
                _dbContext.Event.Add((Event)eventItem);
                eventRaise = new EventCreatedEvent(eventItem);
            }
            _recordsAffected = await _dbContext.SaveChangesAsync();
            eventItem.RaiseDomainEvent(eventRaise);

            return _recordsAffected;
        }
    }
}
