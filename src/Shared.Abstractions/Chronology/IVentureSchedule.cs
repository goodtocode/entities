using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IVentureSchedule : IDomainModel<IVentureSchedule>
    {
        
        
        
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureScheduleKey { get; set; }
    }
}