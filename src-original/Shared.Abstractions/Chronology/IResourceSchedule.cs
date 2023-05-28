using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IResourceSchedule : IDomainEntity<IResourceSchedule>
    {
        
        
        
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid ResourceScheduleKey { get; set; }
    }
}