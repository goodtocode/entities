using GoodToCode.Shared.Models;

namespace GoodToCode.Locality.Models
{
    public sealed class LocationDeletedEvent : IDomainEvent<ILocation>
    {
        public ILocation Item { get; }

        public LocationDeletedEvent(ILocation item)
        {
            Item = item;
        }
    }
}
