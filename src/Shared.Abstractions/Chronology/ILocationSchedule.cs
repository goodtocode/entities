using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ILocationSchedule : IDomainEntity<ILocationSchedule>
    {
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid LocationKey { get; set; }
        Guid LocationScheduleKey { get; set; }
    }
}