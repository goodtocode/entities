using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventAppointment : IDomainEntity<IEventAppointment>
    {
        Guid AppointmentKey { get; set; }
        Guid AppointmentEventKey { get; set; }
        Guid EventKey { get; set; }
    }
}