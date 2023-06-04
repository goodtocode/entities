using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class Schedule : DomainEntity<ISchedule>, ISchedule
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ScheduleKey; } set { ScheduleKey = value; } }
        public Guid ScheduleKey { get; set; }        
        public string ScheduleName { get; set; }
        public string ScheduleDescription { get; set; }
    }
}
