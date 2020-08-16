using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureSchedule : IDomainModel<IVentureSchedule>
    {
        
        
        
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureScheduleKey { get; set; }
    }
}