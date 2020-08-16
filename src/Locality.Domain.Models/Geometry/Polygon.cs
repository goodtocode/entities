using System;
using System.Spatial;

namespace GoodToCode.Locality.Domain.Models
{
    public class Polygon
    {
        public Guid PolygonKey { get; set; }
        public Geometry Area { get; set; }
    }
}
