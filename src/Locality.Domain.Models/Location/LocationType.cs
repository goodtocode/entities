using System;
using System.Collections.Generic;

namespace GoodToCode.Locality.Domain.Models
{
    public class LocationType
    {
        public int LocationTypeId { get; set; }
        public Guid LocationTypeKey { get; set; }
        public string LocationTypeName { get; set; }
        public string LocationTypeDescription { get; set; }
    }
}
