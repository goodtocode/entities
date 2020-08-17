using GoodToCode.Shared.Messaging;
using GoodToCode.Occurrences.Models;
using GoodToCode.Shared.Models;

namespace GoodToCode.Occurrences.Models
{
    public sealed class EventDeletedEvent : IDomainEvent<IEvent>
    {
        public IEvent Item { get; }

        public EventDeletedEvent(IEvent item)
        {
            Item = item;
        }
    }
}
