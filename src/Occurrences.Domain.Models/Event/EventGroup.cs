using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventGroup : DomainModel<IEventGroup>, IEventGroup
    {
        public override Guid RowKey { get { return EventGroupKey; } protected set { EventGroupKey = value; } }
        public Guid EventGroupKey { get; set; }
        public string EventGroupName { get; set; }
        public string EventGroupDescription { get; set; }
    }
}
