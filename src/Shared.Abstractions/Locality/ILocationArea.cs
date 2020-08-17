using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Locality.Models
{
    public interface ILocationArea : IDomainModel<ILocationArea>
    {
        Guid PolygonKey { get; set; }        
        Guid LocationAreaKey { get; set; }
        Guid LocationKey { get; set; }
        
    }
}