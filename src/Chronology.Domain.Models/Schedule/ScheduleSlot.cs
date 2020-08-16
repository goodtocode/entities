using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleSlot
    {
        public Guid ScheduleSlotKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid SlotKey { get; set; }
    }
}
