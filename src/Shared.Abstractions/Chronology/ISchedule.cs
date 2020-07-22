using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public interface ISchedule
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        string ScheduleDescription { get; set; }
        int ScheduleId { get; set; }
        Guid ScheduleKey { get; set; }
        string ScheduleName { get; set; }
    }
}