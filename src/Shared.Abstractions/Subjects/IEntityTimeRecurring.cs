using System;

namespace GoodToCode.Shared.Models
{
    public interface IEntityTimeRecurring
    {
        DateTime CreatedDate { get; set; }
        string DayName { get; set; }
        Guid EntityKey { get; set; }
        int EntityTimeRecurringId { get; set; }
        Guid EntityTimeRecurringKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}