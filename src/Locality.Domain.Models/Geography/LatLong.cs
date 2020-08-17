using GoodToCode.Shared.Models;
using System;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public class LatLong : DomainModel<ILatLong>, ILatLong
    {
        public Guid LatLongKey { get; set; }
        public Point Latitude { get; set; }
        public Point Longitude { get; set; }
    }
}
