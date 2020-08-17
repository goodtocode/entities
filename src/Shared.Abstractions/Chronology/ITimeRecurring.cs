using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ITimeRecurring : IDomainModel<ITimeRecurring>
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