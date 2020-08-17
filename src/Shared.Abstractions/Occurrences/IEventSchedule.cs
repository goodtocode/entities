using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventSchedule : IDomainModel<IEventSchedule>
    {
        Guid EventKey { get; set; }
        Guid EventScheduleKey { get; set; }
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
    }
}