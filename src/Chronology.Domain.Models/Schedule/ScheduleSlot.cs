using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleSlot : DomainModel<IScheduleSlot>, IScheduleSlot
    {
        [Key]
        public Guid ScheduleSlotKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid SlotKey { get; set; }
    }
}
