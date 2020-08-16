using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public class SlotTimeRecurring
    {
        public int SlotTimeRecurringId { get; set; }
        public Guid SlotTimeRecurringKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
