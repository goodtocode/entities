using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class ScheduleSlot
    {
        public int ScheduleSlotId { get; set; }
        public Guid ScheduleSlotKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid SlotKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Schedule ScheduleKeyNavigation { get; set; }
        public virtual Slot SlotKeyNavigation { get; set; }
    }
}
