using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class LocationArea : DomainModel<ILocationArea>, ILocationArea
    {
        public override Guid RowKey { get { return LocationAreaKey; } set { LocationAreaKey = value; } }
        public Guid LocationAreaKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid PolygonKey { get; set; }
    }
}
