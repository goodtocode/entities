using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class TimeCycle
    {
        public TimeCycle()
        {
            TimeRecurring = new HashSet<TimeRecurring>();
        }

        public int TimeCycleId { get; set; }
        public Guid TimeCycleKey { get; set; }
        public string TimeCycleName { get; set; }
        public string TimeCycleDescription { get; set; }
        public int Days { get; set; }
        public int Interval { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<TimeRecurring> TimeRecurring { get; set; }
    }
}
