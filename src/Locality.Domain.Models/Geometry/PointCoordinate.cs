using GoodToCode.Shared.Models;
using System;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public class PointCoordinate : DomainModel<IPointCoordinate>, IPointCoordinate
    {
        public Guid PointKey { get; set; }
        public Point Coordinate { get; set; }
    }
}
