using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class SlotTimeRecurring : DomainModel<ISlotTimeRecurring>, ISlotTimeRecurring
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return SlotTimeRecurringKey; } set { SlotTimeRecurringKey = value; } }
        public Guid SlotTimeRecurringKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
