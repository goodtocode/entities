using GoodToCode.Shared.Domain;
using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations;


namespace GoodToCode.Locality.Models
{
    public class Polygon : DomainEntity<IPolygon>, IPolygon
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return PolygonKey; } set { PolygonKey = value; } }
        public Guid PolygonKey { get; set; }
        public Geometry PolygonSequence { get; set; }
    }
}
