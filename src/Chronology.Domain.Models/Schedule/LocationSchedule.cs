using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class LocationSchedule : DomainModel<ILocationSchedule>, ILocationSchedule
    {
        [Key]
        public Guid LocationScheduleKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
