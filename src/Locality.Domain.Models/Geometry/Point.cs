using System;

namespace GoodToCode.Locality.Domain.Models
{
    public class Point
    {
        public Guid PointKey { get; set; }
        public Point PointLocation { get; set; }
    }
}
