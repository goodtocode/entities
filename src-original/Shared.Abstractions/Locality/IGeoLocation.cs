using GoodToCode.Shared.Domain;
using System;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public interface IGeoLocation : IDomainEntity<IGeoLocation>
    {
        Point Elevation { get; set; }
        Guid GeoLocationKey { get; set; }
        Guid LatLongKey { get; set; }
    }
}