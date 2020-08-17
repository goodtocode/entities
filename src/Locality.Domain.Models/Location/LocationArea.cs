using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class LocationArea : DomainModel<ILocationArea>, ILocationArea
    {
        [Key]
        public Guid LocationAreaKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid PolygonKey { get; set; }
    }
}
