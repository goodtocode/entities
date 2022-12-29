using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class ResourceSchedule : DomainEntity<IResourceSchedule>, IResourceSchedule
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ScheduleKey; } set { ScheduleKey = value; } }
        public Guid ResourceScheduleKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid ScheduleKey { get; set; }        
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
