using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class Event : DomainModel<IEvent>, IEvent
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return EventKey; } set { EventKey = value; } }
        public Guid EventKey { get; set; }
        public Guid EventGroupKey { get; set; }
        public Guid EventTypeKey { get; set; }
        public Guid EventCreatorKey { get; set; }
        public string EventName { get; set; }
        public string EventDescription { get; set; }
        public string EventSlogan { get; set; }
    }
}
