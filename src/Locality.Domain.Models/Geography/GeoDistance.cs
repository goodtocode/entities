using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public class GeoDistance : DomainModel<IGeoDistance>, IGeoDistance
    {
        [Key]
        public Guid GeoDistanceKey { get; set; }
        public Guid StartLatLongKey { get; set; }
        public Guid EndLatLongKey { get; set; }
    }
}
