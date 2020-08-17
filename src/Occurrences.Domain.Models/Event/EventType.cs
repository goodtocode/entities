using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventType : DomainModel<IEventType>, IEventType
    {
        [Key]
        public Guid EventTypeKey { get; set; }
        public Guid EventGroupKey { get; set; }
        public string EventTypeName { get; set; }
        public string EventTypeDescription { get; set; }
    }
}
