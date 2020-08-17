using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public class EventAppointment : DomainModel<IEventAppointment>, IEventAppointment
    {
        public Guid AppointmentEventKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
