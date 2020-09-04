using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class SlotTimeRecurring : DomainModel<ISlotTimeRecurring>, ISlotTimeRecurring
    {
        public override Guid RowKey { get { return SlotTimeRecurringKey; } protected set { SlotTimeRecurringKey = value; } }
        public Guid SlotTimeRecurringKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
