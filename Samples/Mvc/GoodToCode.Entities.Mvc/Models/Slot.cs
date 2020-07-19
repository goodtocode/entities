using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class Slot
    {
        public Slot()
        {
            ScheduleSlot = new HashSet<ScheduleSlot>();
            SlotLocation = new HashSet<SlotLocation>();
            SlotResource = new HashSet<SlotResource>();
            SlotTimeRange = new HashSet<SlotTimeRange>();
            SlotTimeRecurring = new HashSet<SlotTimeRecurring>();
        }

        public int SlotId { get; set; }
        public Guid SlotKey { get; set; }
        public string SlotName { get; set; }
        public string SlotDescription { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual ICollection<ScheduleSlot> ScheduleSlot { get; set; }
        public virtual ICollection<SlotLocation> SlotLocation { get; set; }
        public virtual ICollection<SlotResource> SlotResource { get; set; }
        public virtual ICollection<SlotTimeRange> SlotTimeRange { get; set; }
        public virtual ICollection<SlotTimeRecurring> SlotTimeRecurring { get; set; }
    }
}
