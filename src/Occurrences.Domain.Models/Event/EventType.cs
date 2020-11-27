using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventType : DomainEntity<IEventType>, IEventType
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return EventTypeKey; } set { EventTypeKey = value; } }
        public Guid EventTypeKey { get; set; }
        public Guid EventGroupKey { get; set; }
        public string EventTypeName { get; set; }
        public string EventTypeDescription { get; set; }
    }
}
