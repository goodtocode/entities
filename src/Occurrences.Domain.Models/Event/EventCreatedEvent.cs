using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Models;

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
