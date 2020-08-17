using GoodToCode.Shared.Messaging;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Shared.Models
{
    public sealed class BusinessUpdatedEvent : IDomainEvent<IBusiness>
    {
        public IBusiness Item { get; }

        public BusinessUpdatedEvent(IBusiness item)
        {
            Item = item;
        }
    }
}
