using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public class SlotLocation
    {
        public Guid SlotLocationKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
    }
}
