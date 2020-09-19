using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureResource : DomainModel<IVentureResource>, IVentureResource
    {
        public override Guid RowKey { get { return VentureResourceKey; } set { VentureResourceKey = value; } }
        public Guid VentureResourceKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid? ResourceTypeKey { get; set; }
        
        
    }
}
