
using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Domain;

namespace GoodToCode.Occurrences.Models
{
    public sealed class EventUpdatedEvent : IDomainEvent<IEvent>
    {
        public IEvent Item { get; }

        public EventUpdatedEvent(IEvent item)
        {
            Item = item;
        }
    }
}
