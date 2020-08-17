using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;

namespace GoodToCode.Locality.Models
{
    public class LocationArea : DomainModel<ILocationArea>, ILocationArea
    {
        public Guid LocationAreaKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid AreaKey { get; set; }
    }
}
