using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IScheduleSlot : IDomainEntity<IScheduleSlot>
    {
        Guid ScheduleKey { get; set; }
        Guid ScheduleSlotKey { get; set; }
        Guid SlotKey { get; set; }
    }
}