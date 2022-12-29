using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class ScheduleSlot : DomainEntity<IScheduleSlot>, IScheduleSlot
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ScheduleKey; } set { ScheduleKey = value; } }        
        public Guid ScheduleSlotKey { get; set; }
        public Guid ScheduleKey { get; set; }
        public Guid SlotKey { get; set; }
    }
}
