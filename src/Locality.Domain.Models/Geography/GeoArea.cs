using GoodToCode.Shared.Models;
using NetTopologySuite.Geometries;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GoodToCode.Locality.Models
{
    public class GeoArea : DomainModel<IGeoArea>, IGeoArea
    {
        [Key]
        public Guid GeoAreaKey { get; set; }
        [Column(TypeName = "geography")]
        public Geometry GeodeticArea { get; set; }
    }
}
