using System;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public interface IPointCoordinate
    {
        Guid PointKey { get; set; }
        Point Coordinate { get; set; }
    }
}