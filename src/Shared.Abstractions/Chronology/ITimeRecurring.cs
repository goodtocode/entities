using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public interface ITimeRecurring
    {
        int BeginDay { get; set; }
        DateTime BeginTime { get; set; }
        DateTime CreatedDate { get; set; }
        int EndDay { get; set; }
        DateTime EndTime { get; set; }
        int Interval { get; set; }
        Guid TimeCycleKey { get; set; }
        int TimeRecurringId { get; set; }
        Guid TimeRecurringKey { get; set; }
    }
}