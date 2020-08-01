using GoodToCode.Shared.Messaging;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Shared.Domain
{
    public sealed class EntityDeletedEvent : IDomainEvent<Entity>
    {
        public Entity Item { get; }

        public EntityDeletedEvent(Entity item)
        {
            Item = item;
        }
    }
}
