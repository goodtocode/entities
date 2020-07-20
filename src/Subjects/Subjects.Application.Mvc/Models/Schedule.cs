using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class Schedule
    {
        public Schedule()
        {
            EventSchedule = new HashSet<EventSchedule>();
            ScheduleSlot = new HashSet<ScheduleSlot>();
            VentureSchedule = new HashSet<VentureSchedule>();
        }

        public int ScheduleId { get; set; }
        public Guid ScheduleKey { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleDescription { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual ICollection<EventSchedule> EventSchedule { get; set; }
        public virtual ICollection<ScheduleSlot> ScheduleSlot { get; set; }
        public virtual ICollection<VentureSchedule> VentureSchedule { get; set; }
    }
}
