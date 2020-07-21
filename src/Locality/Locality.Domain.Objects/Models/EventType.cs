using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class EventType : IEventType
    {
        public EventType()
        {
            Event = new HashSet<Event>();
        }

        public int EventTypeId { get; set; }
        public Guid EventTypeKey { get; set; }
        public Guid EventGroupKey { get; set; }
        public string EventTypeName { get; set; }
        public string EventTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual EventGroup EventGroupKeyNavigation { get; set; }
        public virtual ICollection<Event> Event { get; set; }
    }
}
