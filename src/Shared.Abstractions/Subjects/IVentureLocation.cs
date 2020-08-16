using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureLocation : IDomainModel<IVentureLocation>
    {
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureLocationKey { get; set; }
    }
}