using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class SlotTimeRange : ISlotTimeRange
    {
        public int SlotTimeRangeId { get; set; }
        public Guid SlotTimeRangeKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRangeKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Slot SlotKeyNavigation { get; set; }
        public virtual TimeRange TimeRangeKeyNavigation { get; set; }
        public virtual TimeType TimeTypeKeyNavigation { get; set; }
    }
}
