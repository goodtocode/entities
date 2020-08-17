using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IResourceSchedule : IDomainModel<IResourceSchedule>
    {
        
        
        
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid ResourceScheduleKey { get; set; }
    }
}