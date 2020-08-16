using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureAppointment : IDomainModel<IVentureAppointment>
    {
        Guid AppointmentKey { get; set; }
        Guid VentureAppointmentKey { get; set; }
        Guid VentureKey { get; set; }
    }
}