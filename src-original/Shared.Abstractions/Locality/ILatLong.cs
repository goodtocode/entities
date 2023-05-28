using System;
using NetTopologySuite.Geometries;

namespace GoodToCode.Locality.Models
{
    public interface ILatLong
    {
        double Latitude { get; set; }
        Guid LatLongKey { get; set; }
        double Longitude { get; set; }
    }
}