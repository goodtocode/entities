using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public class TimeRecurring
    {
        public Guid TimeRecurringKey { get; set; }
        public int BeginDay { get; set; }
        public int EndDay { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Interval { get; set; }
        public Guid TimeCycleKey { get; set; }
    }
}
