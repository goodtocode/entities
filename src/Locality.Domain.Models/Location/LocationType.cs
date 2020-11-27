using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class LocationType : DomainEntity<ILocationType>, ILocationType
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return LocationTypeKey; } set { LocationTypeKey = value; } }
        public Guid LocationTypeKey { get; set; }
        public string LocationTypeName { get; set; }
        public string LocationTypeDescription { get; set; }
    }
}
