using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class SlotTimeRange : DomainEntity<ISlotTimeRange>, ISlotTimeRange
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return SlotTimeRangeKey; } set { SlotTimeRangeKey = value; } }
        public Guid SlotTimeRangeKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRangeKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
