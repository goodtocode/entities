using NetTopologySuite.Geometries;
using System;

namespace GoodToCode.Locality.Models
{
    public interface IPolygon
    {
        Geometry PolygonSequence { get; set; }
        Guid PolygonKey { get; set; }
    }
}