using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class ResourceSchedule : DomainModel<IResourceSchedule>, IResourceSchedule
    {
        [Key]
        public Guid ResourceScheduleKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid? ScheduleTypeKey { get; set; }
        
        
    }
}
