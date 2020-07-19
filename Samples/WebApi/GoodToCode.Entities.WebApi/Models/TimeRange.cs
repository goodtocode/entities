using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class TimeRange
    {
        public TimeRange()
        {
            Appointment = new HashSet<Appointment>();
            SlotTimeRange = new HashSet<SlotTimeRange>();
        }

        public int TimeRangeId { get; set; }
        public Guid TimeRangeKey { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<Appointment> Appointment { get; set; }
        public virtual ICollection<SlotTimeRange> SlotTimeRange { get; set; }
    }
}
