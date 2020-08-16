using System;

namespace GoodToCode.Locality.Domain.Models
{
    public partial class Line
    {
        public Guid LineKey { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
