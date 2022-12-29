using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventLocation : DomainEntity<IEventLocation>, IEventLocation
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return EventLocationKey; } set { EventLocationKey = value; } }
        public Guid EventLocationKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
    }
}
