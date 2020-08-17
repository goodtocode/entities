using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public class EventOption : DomainModel<IEventOption>, IEventOption
    {
        public Guid EventOptionKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid OptionKey { get; set; }
    }
}
