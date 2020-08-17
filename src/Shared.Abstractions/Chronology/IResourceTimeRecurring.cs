using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IResourceTimeRecurring : IDomainModel<IResourceTimeRecurring>
    {
        string DayName { get; set; }
        Guid ResourceKey { get; set; }
        Guid ResourceTimeRecurringKey { get; set; }
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}