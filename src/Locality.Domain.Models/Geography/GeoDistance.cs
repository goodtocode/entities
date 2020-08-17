using GoodToCode.Shared.Models;
using System;
using System.Spatial;

namespace GoodToCode.Locality.Models
{
    public class GeoDistance : DomainModel<IGeoDistance>, IGeoDistance
    {
        public Guid GeoDistanceKey { get; set; }
        public PointCoordinate StartPoint { get; set; }
        public PointCoordinate EndPoint { get; set; }
        System.Drawing.Point IGeoDistance.EndPoint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        System.Drawing.Point IGeoDistance.StartPoint { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
    }
}
