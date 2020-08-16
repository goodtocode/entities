using System;
using System.Spatial;

namespace GoodToCode.Locality.Domain.Models
{
    public partial class GeoArea
    {
        public Guid GeoAreaKey { get; set; }
        public Geography Area { get; set; }
    }
}
