﻿using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ITimeRecurring : IDomainEntity<ITimeRecurring>
    {
        int BeginDay { get; set; }
        DateTime BeginTime { get; set; }
        
        int EndDay { get; set; }
        DateTime EndTime { get; set; }
        int Interval { get; set; }
        Guid TimeCycleKey { get; set; }
        Guid TimeRecurringKey { get; set; }
    }
}