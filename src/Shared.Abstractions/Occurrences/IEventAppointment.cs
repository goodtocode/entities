using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventAppointment : IDomainModel<IEventAppointment>
    {
        Guid AppointmentKey { get; set; }
        Guid EventAppointmentKey { get; set; }
        Guid EventKey { get; set; }
    }
}