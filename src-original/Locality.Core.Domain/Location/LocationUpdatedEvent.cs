using GoodToCode.Shared.Domain;

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
