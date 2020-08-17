using System;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public interface IGeoDistance
    {
        Point EndPoint { get; set; }
        Guid GeoDistanceKey { get; set; }
        Point StartPoint { get; set; }
    }
}