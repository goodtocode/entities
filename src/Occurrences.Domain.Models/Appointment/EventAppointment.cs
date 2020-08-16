using System;

namespace GoodToCode.Occurrences.Models
{
    public class EventAppointment
    {
        public Guid EventAppointmentKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
