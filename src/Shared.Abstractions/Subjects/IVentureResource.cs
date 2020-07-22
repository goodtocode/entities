using System;

namespace GoodToCode.Shared.Models
{
    public interface IVentureResource
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid? ResourceTypeKey { get; set; }
        Guid VentureKey { get; set; }
        int VentureResourceId { get; set; }
        Guid VentureResourceKey { get; set; }
    }
}