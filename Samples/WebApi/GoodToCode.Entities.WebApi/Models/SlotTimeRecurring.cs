using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class SlotTimeRecurring
    {
        public int SlotTimeRecurringId { get; set; }
        public Guid SlotTimeRecurringKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Slot SlotKeyNavigation { get; set; }
        public virtual TimeRecurring TimeRecurringKeyNavigation { get; set; }
        public virtual TimeType TimeTypeKeyNavigation { get; set; }
    }
}
