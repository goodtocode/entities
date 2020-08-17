using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventAppointment : IDomainModel<IEventAppointment>
    {
        Guid AppointmentKey { get; set; }
        Guid AppointmentEventKey { get; set; }
        Guid EventKey { get; set; }
    }
}