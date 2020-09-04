using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class LocationTimeRecurring : DomainModel<ILocationTimeRecurring>, ILocationTimeRecurring
    {
        public override Guid RowKey { get { return LocationTimeRecurringKey; } protected set { LocationTimeRecurringKey = value; } }
        public Guid LocationTimeRecurringKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
