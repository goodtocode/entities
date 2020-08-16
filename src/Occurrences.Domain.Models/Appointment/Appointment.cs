using System;

namespace GoodToCode.Occurrences.Models
{
    public class Appointment
    {
        public Guid AppointmentKey { get; set; }
        public string AppointmentName { get; set; }
        public string AppointmentDescription { get; set; }
        public Guid? SlotLocationKey { get; set; }
        public Guid? SlotResourceKey { get; set; }
        public Guid TimeRangeKey { get; set; }
    }
}
