using System;
using System.Spatial;

namespace GoodToCode.Locality.Models
{
    public interface IPolygon
    {
        Geometry Sequence { get; set; }
        Guid PolygonKey { get; set; }
    }
}