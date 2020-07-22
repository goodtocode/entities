using System;

namespace GoodToCode.Shared.Models
{
    public interface IVentureSchedule
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid VentureKey { get; set; }
        int VentureScheduleId { get; set; }
        Guid VentureScheduleKey { get; set; }
    }
}