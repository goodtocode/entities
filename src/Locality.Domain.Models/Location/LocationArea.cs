using System;
using System.Collections.Generic;

namespace GoodToCode.Locality.Domain.Models
{
    public class LocationArea
    {
        public Guid LocationAreaKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid AreaKey { get; set; }
    }
}
