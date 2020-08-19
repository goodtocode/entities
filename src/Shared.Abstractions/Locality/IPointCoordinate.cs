using System;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public interface ICoordinate
    {
        Guid CoordinateKey { get; set; }
        Point CoordinatePoint { get; set; }
    }
}