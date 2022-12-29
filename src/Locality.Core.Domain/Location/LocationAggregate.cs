using GoodToCode.Shared.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace GoodToCode.Locality.Models
{
    public class LocationAggregate : DomainAggregate<LocationAggregate>
    {
        private readonly ILocalityDbContext _dbContext;
        private int _recordsAffected;

        public LocationAggregate(int recordsAffected)
        {
            _recordsAffected = recordsAffected;
        }

        public LocationAggregate(ILocalityDbContext context)
        {
            _dbContext = context;
        }

        // Location
        public async Task<int> LocationSaveAsync(ILocation location)
        {
            // Record in local storage

            IDomainEvent<ILocation> eventRaise;

            if (location.LocationKey != Guid.Empty)
            {
                _dbContext.Entry((Location)location).State = EntityState.Modified;
                eventRaise = new LocationUpdatedEvent(location);
            }
            else
            {
                _dbContext.Location.Add((Location)location);
                eventRaise = new LocationCreatedEvent(location);
            }
            _recordsAffected = await _dbContext.SaveChangesAsync();            
            location.RaiseDomainEvent(eventRaise);

            return _recordsAffected;
        }
        public async Task<int> LocationDeleteAsync(ILocation location)
        {
            // Record in local storage

            IDomainEvent<ILocation> eventRaise;

            if (location.LocationKey != Guid.Empty)
            {
                _dbContext.Entry((Location)location).State = EntityState.Deleted;
                eventRaise = new LocationUpdatedEvent(location);
            }
            else
            {
                _dbContext.Location.Add((Location)location);
                eventRaise = new LocationCreatedEvent(location);
            }
            _recordsAffected = await _dbContext.SaveChangesAsync();
            location.RaiseDomainEvent(eventRaise);

            return _recordsAffected;
        }
    }
}
