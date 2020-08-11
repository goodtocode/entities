using System;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociateTimeRecurring
    {
        DateTime CreatedDate { get; set; }
        string DayName { get; set; }
        Guid AssociateKey { get; set; }
        Guid AssociateTimeRecurringKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}