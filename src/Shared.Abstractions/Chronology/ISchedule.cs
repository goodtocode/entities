using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public interface ISchedule
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string ScheduleDescription { get; set; }
        Guid ScheduleKey { get; set; }
        string ScheduleName { get; set; }
    }
}