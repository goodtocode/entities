using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public interface ISchedule : IDomainEntity<ISchedule>
    {
        string ScheduleDescription { get; set; }
        Guid ScheduleKey { get; set; }
        string ScheduleName { get; set; }
    }
}