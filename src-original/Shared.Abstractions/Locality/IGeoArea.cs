using System;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public interface IGeoArea
    {
        Guid GeoAreaKey { get; set; }
        Geometry GeodeticArea { get; set; }
    }
}