using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class Schedule : DomainModel<ISchedule>, ISchedule
    {
        [Key]
        public Guid ScheduleKey { get; set; }
        public string ScheduleName { get; set; }
        public string ScheduleDescription { get; set; }
    }
}
