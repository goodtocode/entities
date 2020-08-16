using System;
using System.Collections.Generic;

namespace GoodToCode.Locality.Domain.Models
{
    public class LocationTimeRecurring
    {
        public int LocationTimeRecurringId { get; set; }
        public Guid LocationTimeRecurringKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid TimeRecurringKey { get; set; }
        public string DayName { get; set; }
        public string TimeName { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
