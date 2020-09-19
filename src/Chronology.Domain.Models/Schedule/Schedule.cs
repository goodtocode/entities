using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class Schedule : DomainModel<ISchedule>, ISchedule
    {
        
        public Guid ScheduleKey { get; set; }
        public override Guid RowKey { get { return ScheduleKey; } set { ScheduleKey = value; } }
        public string ScheduleName { get; set; }
        public string ScheduleDescription { get; set; }
    }
}
