using System;
using System.Drawing;

namespace GoodToCode.Locality.Models
{
    public interface ILine
    {
        Point EndPoint { get; set; }
        Guid LineKey { get; set; }
        Point StartPoint { get; set; }
    }
}