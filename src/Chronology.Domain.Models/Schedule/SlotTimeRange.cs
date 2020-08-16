using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public class SlotTimeRange : DomainModel<ISlotTimeRange>, ISlotTimeRange
    {
        public Guid SlotTimeRangeKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRangeKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
