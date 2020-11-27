using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventDetail : DomainEntity<IEventDetail>, IEventDetail
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return EventDetailKey; } set { EventDetailKey = value; } }
        public Guid EventDetailKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid DetailKey { get; set; }
    }
}
