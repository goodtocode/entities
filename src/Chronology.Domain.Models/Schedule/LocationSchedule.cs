using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class LocationSchedule : DomainModel<ILocationSchedule>, ILocationSchedule
    {
        
        public Guid LocationScheduleKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public override Guid RowKey { get { return ScheduleKey; } set { ScheduleKey = value; } }
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
