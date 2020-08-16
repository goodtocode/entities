using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureResource : IDomainModel<IVentureResource>
    {
        Guid ResourceKey { get; set; }
        Guid? ResourceTypeKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureResourceKey { get; set; }
    }
}