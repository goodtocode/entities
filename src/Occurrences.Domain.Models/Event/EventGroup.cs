using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventGroup : DomainEntity<IEventGroup>, IEventGroup
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return EventGroupKey; } set { EventGroupKey = value; } }
        public Guid EventGroupKey { get; set; }
        public string EventGroupName { get; set; }
        public string EventGroupDescription { get; set; }
    }
}
