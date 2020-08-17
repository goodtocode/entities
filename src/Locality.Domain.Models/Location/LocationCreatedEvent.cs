using GoodToCode.Shared.Models;

namespace GoodToCode.Locality.Models
{
    public sealed class LocationCreatedEvent : IDomainEvent<ILocation>
    {
        public ILocation Item { get; }

        public LocationCreatedEvent(ILocation item)
        {
            Item = item;
        }
    }
}
