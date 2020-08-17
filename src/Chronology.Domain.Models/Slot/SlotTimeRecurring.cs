using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public class SlotTimeRecurring : DomainModel<ISlotTimeRecurring>, ISlotTimeRecurring
    {
        public int SlotTimeRecurringId { get; set; }
        public Guid SlotTimeRecurringKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
