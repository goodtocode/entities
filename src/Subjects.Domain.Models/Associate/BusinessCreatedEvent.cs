using GoodToCode.Subjects.Models;

namespace GoodToCode.Shared.Domain
{
    public sealed class BusinessCreatedEvent : IDomainEvent<IBusiness>
    {
        public IBusiness Item { get; }

        public BusinessCreatedEvent(IBusiness item)
        {
            Item = item;
        }
    }
}
