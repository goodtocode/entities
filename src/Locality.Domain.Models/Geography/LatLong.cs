using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public class LatLong : DomainModel<ILatLong>, ILatLong
    {
        [Key]
        public Guid LatLongKey { get; set; }
        public Point Latitude { get; set; }
        public Point Longitude { get; set; }
    }
}
