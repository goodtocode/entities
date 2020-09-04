using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventOption : DomainModel<IEventOption>, IEventOption
    {
        public override Guid RowKey { get { return EventOptionKey; } protected set { EventOptionKey = value; } }
        public Guid EventOptionKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid OptionKey { get; set; }
    }
}
