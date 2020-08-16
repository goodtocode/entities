using System;

namespace GoodToCode.Locality.Domain.Models
{
    public partial class Point
    {
        public Guid PointKey { get; set; }
        public Point PointLocation { get; set; }
    }
}
