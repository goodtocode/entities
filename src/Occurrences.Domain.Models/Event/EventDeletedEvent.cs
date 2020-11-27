using GoodToCode.Shared.Domain;

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
