using GoodToCode.Shared.Domain;
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
