using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class LocationTimeRecurring : ILocationTimeRecurring
    {
        public int LocationTimeRecurringId { get; set; }
        public Guid LocationTimeRecurringKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Location LocationKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual TimeRecurring TimeRecurringKeyNavigation { get; set; }
        public virtual TimeType TimeTypeKeyNavigation { get; set; }
    }
}
