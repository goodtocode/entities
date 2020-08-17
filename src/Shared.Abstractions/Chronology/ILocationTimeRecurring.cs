using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ILocationTimeRecurring : IDomainModel<ILocationTimeRecurring>
    {        
        string DayName { get; set; }
        Guid LocationKey { get; set; }
        Guid LocationTimeRecurringKey { get; set; }                
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}