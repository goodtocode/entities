using GoodToCode.Shared.Messaging;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Shared.Domain
{
    public sealed class EntityCreatedEvent : IDomainEvent<Business>
    {
        public Business Item { get; }

        public EntityCreatedEvent(Business item)
        {
            Item = item;
        }
    }
}
