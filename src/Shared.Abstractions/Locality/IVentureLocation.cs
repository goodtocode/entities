using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Locality.Models
{
    public interface IVentureLocation : IDomainModel<IVentureLocation>
    {
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureLocationKey { get; set; }
    }
}