using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureSchedule
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureScheduleKey { get; set; }
    }
}