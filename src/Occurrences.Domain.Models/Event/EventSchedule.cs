using System;

namespace GoodToCode.Occurrences.Models
{
    public class EventSchedule
    {
        public Guid EventScheduleKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
    }
}
