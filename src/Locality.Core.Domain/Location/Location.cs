using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class Location : DomainEntity<ILocation>, ILocation
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return LocationKey; } set { LocationKey = value; } }
        public Guid LocationKey { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
    }
}
