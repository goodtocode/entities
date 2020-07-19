using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class TimeType
    {
        public TimeType()
        {
            EntityTimeRecurring = new HashSet<EntityTimeRecurring>();
            LocationTimeRecurring = new HashSet<LocationTimeRecurring>();
            ResourceTimeRecurring = new HashSet<ResourceTimeRecurring>();
            SlotTimeRange = new HashSet<SlotTimeRange>();
            SlotTimeRecurring = new HashSet<SlotTimeRecurring>();
        }

        public int TimeTypeId { get; set; }
        public Guid TimeTypeKey { get; set; }
        public string TimeTypeName { get; set; }
        public string TimeTypeDescription { get; set; }
        public int TimeBehavior { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<EntityTimeRecurring> EntityTimeRecurring { get; set; }
        public virtual ICollection<LocationTimeRecurring> LocationTimeRecurring { get; set; }
        public virtual ICollection<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual ICollection<SlotTimeRange> SlotTimeRange { get; set; }
        public virtual ICollection<SlotTimeRecurring> SlotTimeRecurring { get; set; }
    }
}
