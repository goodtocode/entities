using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IScheduleSlot : IDomainModel<IScheduleSlot>
    {
        Guid ScheduleKey { get; set; }
        Guid ScheduleSlotKey { get; set; }
        Guid SlotKey { get; set; }
    }
}