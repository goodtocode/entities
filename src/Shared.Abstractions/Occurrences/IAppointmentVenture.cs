using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IAppointmentVenture : IDomainModel<IAppointmentVenture>
    {
        Guid AppointmentKey { get; set; }
        Guid AppointmentVentureKey { get; set; }
        Guid VentureKey { get; set; }
    }
}