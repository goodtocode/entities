using System;
using System.Spatial;

namespace GoodToCode.Locality.Models
{
    public interface IGeoArea
    {
        Guid PolygonKey { get; set; }
        Guid GeoAreaKey { get; set; }
    }
}