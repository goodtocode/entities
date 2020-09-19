using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventDetail : DomainModel<IEventDetail>, IEventDetail
    {
        public override Guid RowKey { get { return EventDetailKey; } set { EventDetailKey = value; } }
        public Guid EventDetailKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid DetailKey { get; set; }
    }
}
