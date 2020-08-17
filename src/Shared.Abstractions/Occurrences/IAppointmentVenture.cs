using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IVentureAppointment : IDomainModel<IVentureAppointment>
    {
        Guid AppointmentKey { get; set; }
        Guid VentureAppointmentKey { get; set; }
        Guid VentureKey { get; set; }
    }
}