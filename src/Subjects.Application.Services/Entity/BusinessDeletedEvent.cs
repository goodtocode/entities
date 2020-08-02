using GoodToCode.Shared.Messaging;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Shared.Domain
{
    public sealed class BusinessDeletedEvent : IDomainEvent<IBusiness>
    {
        public IBusiness Item { get; }

        public BusinessDeletedEvent(IBusiness item)
        {
            Item = item;
        }
    }
}
