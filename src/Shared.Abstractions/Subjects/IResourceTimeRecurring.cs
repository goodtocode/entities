using System;

namespace GoodToCode.Subjects.Models
{
    public interface IResourceTimeRecurring
    {
        DateTime CreatedDate { get; set; }
        string DayName { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid ResourceKey { get; set; }
        int ResourceTimeRecurringId { get; set; }
        Guid ResourceTimeRecurringKey { get; set; }
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}