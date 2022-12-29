
using GoodToCode.Shared.Domain;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Shared.Models
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
