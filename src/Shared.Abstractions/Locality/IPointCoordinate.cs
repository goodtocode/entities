using System;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public interface IPointCoordinate
    {
        Guid PointCoordinateKey { get; set; }
        Point Coordinate { get; set; }
    }
}