using System;
using System.Collections.Generic;
using System.Drawing;

namespace GoodToCode.Locality.Domain.Models
{
    public partial class LatLong
    {
        public Guid LatLongKey { get; set; }
        public Point Latitude { get; set; }
        public Point Longitude { get; set; }
    }
}
