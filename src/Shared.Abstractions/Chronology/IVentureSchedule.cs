using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IVentureSchedule : IDomainEntity<IVentureSchedule>
    {
        
        
        
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureScheduleKey { get; set; }
    }
}