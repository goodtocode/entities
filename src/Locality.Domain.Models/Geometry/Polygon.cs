using GoodToCode.Shared.Models;
using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations;


namespace GoodToCode.Locality.Models
{
    public class Polygon : DomainModel<IPolygon>, IPolygon
    {
        [Key]
        public Guid PolygonKey { get; set; }
        public Geometry PolygonSequence { get; set; }
    }
}
