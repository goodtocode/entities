using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class VentureLocation : DomainEntity<IVentureLocation>, IVentureLocation
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return VentureLocationKey; } set { VentureLocationKey = value; } }
        public Guid VentureLocationKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        
        
    }
}
