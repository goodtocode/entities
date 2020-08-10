using System;

namespace GoodToCode.Locality.Models
{
    public interface ILocationTimeRecurring
    {
        DateTime CreatedDate { get; set; }
        string DayName { get; set; }
        Guid LocationKey { get; set; }
        Guid LocationTimeRecurringKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}