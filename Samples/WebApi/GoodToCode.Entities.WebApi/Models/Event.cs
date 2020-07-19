using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class Event
    {
        public Event()
        {
            EventAppointment = new HashSet<EventAppointment>();
            EventDetail = new HashSet<EventDetail>();
            EventEntityOption = new HashSet<EventEntityOption>();
            EventLocation = new HashSet<EventLocation>();
            EventOption = new HashSet<EventOption>();
            EventResource = new HashSet<EventResource>();
            EventSchedule = new HashSet<EventSchedule>();
        }

        public int EventId { get; set; }
        public Guid EventKey { get; set; }
        public Guid EventGroupKey { get; set; }
        public Guid EventTypeKey { get; set; }
        public Guid EventCreatorKey { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventSlogan { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Entity EventCreatorKeyNavigation { get; set; }
        public virtual EventGroup EventGroupKeyNavigation { get; set; }
        public virtual EventType EventTypeKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual ICollection<EventAppointment> EventAppointment { get; set; }
        public virtual ICollection<EventDetail> EventDetail { get; set; }
        public virtual ICollection<EventEntityOption> EventEntityOption { get; set; }
        public virtual ICollection<EventLocation> EventLocation { get; set; }
        public virtual ICollection<EventOption> EventOption { get; set; }
        public virtual ICollection<EventResource> EventResource { get; set; }
        public virtual ICollection<EventSchedule> EventSchedule { get; set; }
    }
}
