using GoodToCode.Shared.Models;
using GoodToCode.Shared.Messaging;
using GoodToCode.Subjects.Models;

namespace GoodToCode.Locality.Models
{
    public sealed class LocationUpdatedEvent : IDomainEvent<ILocation>
    {
        public ILocation Item { get; }

        public LocationUpdatedEvent(ILocation item)
        {
            Item = item;
        }
    }
}
