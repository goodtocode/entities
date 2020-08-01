using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotTimeRecurring
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid SlotKey { get; set; }
        int SlotTimeRecurringId { get; set; }
        Guid SlotTimeRecurringKey { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}