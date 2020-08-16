using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public class EventEntityOption
    {
        public Guid EventEntityOptionKey { get; set; }
        public Guid OptionKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid EntityKey { get; set; }
    }
}
