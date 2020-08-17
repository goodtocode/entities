using System;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public interface ILatLong
    {
        Point Latitude { get; set; }
        Guid LatLongKey { get; set; }
        Point Longitude { get; set; }
    }
}