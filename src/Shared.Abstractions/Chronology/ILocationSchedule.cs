using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ILocationSchedule : IDomainModel<ILocationSchedule>
    {
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid LocationKey { get; set; }
        Guid LocationScheduleKey { get; set; }
    }
}