using GoodToCode.Shared.Models;
using System;
using System.Spatial;

namespace GoodToCode.Locality.Models
{
    public class GeoArea : DomainModel<IGeoArea>, IGeoArea
    {
        public Guid GeoAreaKey { get; set; }
        public Geography Area { get; set; }
    }
}
