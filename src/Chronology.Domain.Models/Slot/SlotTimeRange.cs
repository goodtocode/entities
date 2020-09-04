using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class SlotTimeRange : DomainModel<ISlotTimeRange>, ISlotTimeRange
    {
        public override Guid RowKey { get { return SlotTimeRangeKey; } protected set { SlotTimeRangeKey = value; } }
        public Guid SlotTimeRangeKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRangeKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
