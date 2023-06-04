using System;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public interface IGeoDistance
    {
        Guid GeoDistanceKey { get; set; }
        Guid StartLatLongKey { get; set; }
        Guid EndLatLongKey { get; set; }
    }
}