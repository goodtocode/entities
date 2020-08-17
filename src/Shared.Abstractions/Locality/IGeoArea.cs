using System;
using System.Spatial;

namespace GoodToCode.Locality.Models
{
    public interface IGeoArea
    {
        Geography Area { get; set; }
        Guid GeoAreaKey { get; set; }
    }
}