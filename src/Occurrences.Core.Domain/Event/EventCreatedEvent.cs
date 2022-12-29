using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Domain;

namespace GoodToCode.Occurrences.Models
{
    public sealed class EventCreatedEvent : IDomainEvent<IEvent>
    {
        public IEvent Item { get; }

        public EventCreatedEvent(IEvent item)
        {
            Item = item;
        }
    }
}
