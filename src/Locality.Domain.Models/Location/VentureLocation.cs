using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class VentureLocation : DomainModel<IVentureLocation>, IVentureLocation
    {
        public override Guid RowKey { get { return VentureLocationKey; } protected set { VentureLocationKey = value; } }
        public Guid VentureLocationKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        
        
    }
}
