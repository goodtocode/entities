using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public class SlotTimeRange
    {
        public Guid SlotTimeRangeKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRangeKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
