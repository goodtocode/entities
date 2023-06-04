﻿using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotTimeRange : IDomainEntity<ISlotTimeRange>
    {
        Guid SlotKey { get; set; }
        Guid SlotTimeRangeKey { get; set; }
        Guid TimeRangeKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}