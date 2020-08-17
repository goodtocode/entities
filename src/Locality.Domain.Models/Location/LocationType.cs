using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;

namespace GoodToCode.Locality.Models
{
    public class LocationType : DomainModel<ILocationType>, ILocationType
    {
        public int LocationTypeId { get; set; }
        public Guid LocationTypeKey { get; set; }
        public string LocationTypeName { get; set; }
        public string LocationTypeDescription { get; set; }
    }
}
