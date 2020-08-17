using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public interface ISchedule : IDomainModel<ISchedule>
    {
        string ScheduleDescription { get; set; }
        Guid ScheduleKey { get; set; }
        string ScheduleName { get; set; }
    }
}