using GoodToCode.Shared.Messaging;
using GoodToCode.Shared.Models;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Shared.Domain
{
    public sealed class EntityUpdatedEvent : IDomainEvent<Entity>
    {
        public Entity Item { get; }

        public EntityUpdatedEvent(Entity item)
        {
            Item = item;
        }
    }
}
