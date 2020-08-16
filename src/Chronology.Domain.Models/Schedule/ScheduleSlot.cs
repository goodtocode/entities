using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleSlot : DomainModel<IScheduleSlot>, IScheduleSlot
    {
        public Guid ScheduleSlotKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid SlotKey { get; set; }
    }
}
