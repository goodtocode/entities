﻿using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventSchedule : IDomainEntity<IEventSchedule>
    {
        Guid EventKey { get; set; }
        Guid EventScheduleKey { get; set; }
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
    }
}