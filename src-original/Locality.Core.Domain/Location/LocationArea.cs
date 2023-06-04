using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class LocationArea : DomainEntity<ILocationArea>, ILocationArea
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return LocationAreaKey; } set { LocationAreaKey = value; } }
        public Guid LocationAreaKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid PolygonKey { get; set; }
    }
}
