using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Spatial;

namespace GoodToCode.Locality.Models
{
    public class GeoArea : DomainModel<IGeoArea>, IGeoArea
    {
        [Key]
        public Guid GeoAreaKey { get; set; }
        public Guid PolygonKey { get; set; }
    }
}
