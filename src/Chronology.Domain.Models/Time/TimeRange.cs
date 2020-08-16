using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public class TimeRange
    {
        public Guid TimeRangeKey { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
