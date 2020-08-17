using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotTimeRecurring : IDomainModel<ISlotTimeRecurring>
    {
        
        
        
        Guid SlotKey { get; set; }
        Guid SlotTimeRecurringKey { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}