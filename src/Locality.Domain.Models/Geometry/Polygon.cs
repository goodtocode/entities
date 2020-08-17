using GoodToCode.Shared.Models;
using System;
using System.Spatial;

namespace GoodToCode.Locality.Models
{
    public class Polygon : DomainModel<IPolygon>, IPolygon
    {
        public Guid PolygonKey { get; set; }
        public Geometry Area { get; set; }
    }
}
