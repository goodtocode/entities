using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class EventSchedule
    {
        public int EventScheduleId { get; set; }
        public Guid EventScheduleKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Event EventKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Schedule ScheduleKeyNavigation { get; set; }
        public virtual ScheduleType ScheduleTypeKeyNavigation { get; set; }
    }
}
