using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IVentureAppointment : IDomainEntity<IVentureAppointment>
    {
        Guid AppointmentKey { get; set; }
        Guid VentureAppointmentKey { get; set; }
        Guid VentureKey { get; set; }
    }
}