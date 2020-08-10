using System;

namespace GoodToCode.Subjects.Models
{
    public interface IEntityTimeRecurring
    {
        DateTime CreatedDate { get; set; }
        string DayName { get; set; }
        Guid EntityKey { get; set; }
        Guid EntityTimeRecurringKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}