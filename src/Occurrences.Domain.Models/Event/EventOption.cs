using System;

namespace GoodToCode.Occurrences.Models
{
    public class EventOption
    {
        public Guid EventOptionKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid OptionKey { get; set; }
    }
}
