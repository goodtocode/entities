using GoodToCode.Shared.Models;
using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations;


namespace GoodToCode.Locality.Models
{
    public class Polygon : DomainModel<IPolygon>, IPolygon
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return PolygonKey; } set { PolygonKey = value; } }
        public Guid PolygonKey { get; set; }
        public Geometry PolygonSequence { get; set; }
    }
}
