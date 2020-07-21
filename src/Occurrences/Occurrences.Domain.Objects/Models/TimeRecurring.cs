using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class TimeRecurring : ITimeRecurring
    {
        public TimeRecurring()
        {
            EntityTimeRecurring = new HashSet<EntityTimeRecurring>();
            LocationTimeRecurring = new HashSet<LocationTimeRecurring>();
            ResourceTimeRecurring = new HashSet<ResourceTimeRecurring>();
            SlotTimeRecurring = new HashSet<SlotTimeRecurring>();
        }

        public int TimeRecurringId { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public int BeginDay { get; set; }
        public int EndDay { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Interval { get; set; }
        public Guid TimeCycleKey { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual TimeCycle TimeCycleKeyNavigation { get; set; }
        public virtual ICollection<EntityTimeRecurring> EntityTimeRecurring { get; set; }
        public virtual ICollection<LocationTimeRecurring> LocationTimeRecurring { get; set; }
        public virtual ICollection<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual ICollection<SlotTimeRecurring> SlotTimeRecurring { get; set; }
    }
}
