using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IVentureTimeRecurring : IDomainModel<IVentureTimeRecurring>
    {
        string DayName { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureTimeRecurringKey { get; set; }
        string TimeName { get; set; }
        Guid TimeRecurringKey { get; set; }
        Guid? TimeTypeKey { get; set; }
    }
}