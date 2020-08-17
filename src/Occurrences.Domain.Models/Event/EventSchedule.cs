using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventSchedule : DomainModel<IEventSchedule>, IEventSchedule
    {
        [Key]
        public Guid EventScheduleKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
    }
}
