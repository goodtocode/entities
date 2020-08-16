using System;
using System.Collections.Generic;
using System.Drawing;

namespace GoodToCode.Locality.Domain.Models
{
    public class GeoLocation
    {
        public Guid GeoLocationKey { get; set; }
        public Guid LatLongKey { get; set; }
        public Point Latitude { get; set; }
        public Point Longitude { get; set; }
        public Point Elevation { get; set; }

    }
}
