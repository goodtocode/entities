using System;

namespace GoodToCode.Shared.Models
{
    public interface ILocationTimeRecurring
    {
        DateTime CreatedDate { get; set; }
        string DayName { get; set; }
        Guid LocationKey { get; set; }
        int LocationTimeRecurringId { get; set; }
        Guid LocationTimeRecurringKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}