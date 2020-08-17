using GoodToCode.Shared.Models;
using System;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public class Line : DomainModel<ILine>, ILine
    {
        public Guid LineKey { get; set; }
        public Point StartPoint { get; set; }
        public Point EndPoint { get; set; }
    }
}
