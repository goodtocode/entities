﻿using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotTimeRecurring : IDomainEntity<ISlotTimeRecurring>
    {
        
        
        
        Guid SlotKey { get; set; }
        Guid SlotTimeRecurringKey { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}