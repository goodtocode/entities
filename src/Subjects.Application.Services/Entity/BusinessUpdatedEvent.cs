using GoodToCode.Shared.Messaging;
using GoodToCode.Shared.Models;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Shared.Domain
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
