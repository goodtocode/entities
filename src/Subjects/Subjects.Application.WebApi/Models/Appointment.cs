using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class Appointment
    {
        public Appointment()
        {
            EntityAppointment = new HashSet<EntityAppointment>();
            EventAppointment = new HashSet<EventAppointment>();
            VentureAppointment = new HashSet<VentureAppointment>();
        }

        public int AppointmentId { get; set; }
        public Guid AppointmentKey { get; set; }
        public string AppointmentName { get; set; }
        public string AppointmentDescription { get; set; }
        public Guid? SlotLocationKey { get; set; }
        public Guid? SlotResourceKey { get; set; }
        public Guid TimeRangeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual SlotLocation SlotLocationKeyNavigation { get; set; }
        public virtual SlotResource SlotResourceKeyNavigation { get; set; }
        public virtual TimeRange TimeRangeKeyNavigation { get; set; }
        public virtual ICollection<EntityAppointment> EntityAppointment { get; set; }
        public virtual ICollection<EventAppointment> EventAppointment { get; set; }
        public virtual ICollection<VentureAppointment> VentureAppointment { get; set; }
    }
}
