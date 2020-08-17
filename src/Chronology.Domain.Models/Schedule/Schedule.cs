using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public class Schedule : DomainModel<ISchedule>, ISchedule
    {
        public Guid ScheduleKey { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleDescription { get; set; }
    }
}
