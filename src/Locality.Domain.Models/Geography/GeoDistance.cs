using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public class GeoDistance : DomainModel<IGeoDistance>, IGeoDistance
    {
        [Key]
        public Guid GeoDistanceKey { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
