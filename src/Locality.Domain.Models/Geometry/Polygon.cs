using GoodToCode.Shared.Models;
using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations;


namespace GoodToCode.Locality.Models
{
    public class Polygon : DomainModel<IPolygon>, IPolygon
    {
        public override Guid RowKey { get { return PolygonKey; } protected set { PolygonKey = value; } }
        public Guid PolygonKey { get; set; }
        public Geometry PolygonSequence { get; set; }
    }
}
