using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleSlot : DomainModel<IScheduleSlot>, IScheduleSlot
    {
        public override Guid RowKey { get { return ScheduleKey; } set { ScheduleKey = value; } }        
        public Guid ScheduleSlotKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid SlotKey { get; set; }
    }
}
