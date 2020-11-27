using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Locality.Models
{
    public interface IVentureLocation : IDomainEntity<IVentureLocation>
    {
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureLocationKey { get; set; }
    }
}