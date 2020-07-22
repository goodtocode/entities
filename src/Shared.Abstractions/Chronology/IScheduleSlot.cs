using System;

namespace GoodToCode.Shared.Models
{
    public interface IScheduleSlot
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid ScheduleKey { get; set; }
        int ScheduleSlotId { get; set; }
        Guid ScheduleSlotKey { get; set; }
        Guid SlotKey { get; set; }
    }
}