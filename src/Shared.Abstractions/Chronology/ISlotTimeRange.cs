using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotTimeRange : IDomainModel<ISlotTimeRange>
    {
        Guid SlotKey { get; set; }
        Guid SlotTimeRangeKey { get; set; }
        Guid TimeRangeKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}