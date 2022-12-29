using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventOption : DomainEntity<IEventOption>, IEventOption
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return EventOptionKey; } set { EventOptionKey = value; } }
        public Guid EventOptionKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid OptionKey { get; set; }
    }
}
