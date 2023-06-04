using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IAssociateTimeRecurring : IDomainEntity<IAssociateTimeRecurring>
    {
        string DayName { get; set; }
        Guid AssociateKey { get; set; }
        Guid AssociateTimeRecurringKey { get; set; }
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}