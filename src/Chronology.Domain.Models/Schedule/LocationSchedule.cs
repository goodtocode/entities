using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class LocationSchedule : DomainEntity<ILocationSchedule>, ILocationSchedule
    {
        public override Guid RowKey { get { return ScheduleKey; } set { ScheduleKey = value; } }
        public override string PartitionKey { get; set; } = "Default";
        public Guid LocationScheduleKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid ScheduleKey { get; set; }        
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
