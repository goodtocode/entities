using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Locality.Models
{
    public interface ILocationArea : IDomainEntity<ILocationArea>
    {
        Guid PolygonKey { get; set; }        
        Guid LocationAreaKey { get; set; }
        Guid LocationKey { get; set; }
        
    }
}