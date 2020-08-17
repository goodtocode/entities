using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Spatial;

namespace GoodToCode.Locality.Models
{
    public class Polygon : DomainModel<IPolygon>, IPolygon
    {
        [Key]
        public Guid PolygonKey { get; set; }
        public Geometry Area { get; set; }
    }
}
