using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class ResourceTimeRecurring : IResourceTimeRecurring
    {
        public int ResourceTimeRecurringId { get; set; }
        public Guid ResourceTimeRecurringKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Resource ResourceKeyNavigation { get; set; }
        public virtual TimeRecurring TimeRecurringKeyNavigation { get; set; }
        public virtual TimeType TimeTypeKeyNavigation { get; set; }
    }
}
