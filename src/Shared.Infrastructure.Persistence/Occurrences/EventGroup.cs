using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public partial class EventGroup : IEventGroup
    {
        public EventGroup()
        {
            Event = new HashSet<Event>();
            EventType = new HashSet<EventType>();
        }

        public int EventGroupId { get; set; }
        public Guid EventGroupKey { get; set; }
        public string EventGroupName { get; set; }
        public string EventGroupDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Event> Event { get; set; }
        public virtual ICollection<EventType> EventType { get; set; }
    }
}
