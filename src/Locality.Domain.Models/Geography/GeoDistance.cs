using System;
using System.Spatial;

namespace GoodToCode.Locality.Domain.Models
{
    public partial class GeoDistance
    {
        public Guid GeoDistanceKey { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
