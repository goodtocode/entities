using System;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public interface ILine
    {
        Guid LineKey { get; set; }
        Point StartPoint { get; set; }
        Point EndPoint { get; set; }        
    }
}