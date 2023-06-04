using GoodToCode.Shared.Domain;

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
