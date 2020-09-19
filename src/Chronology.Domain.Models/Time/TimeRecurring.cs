using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class TimeRecurring : DomainModel<ITimeRecurring>, ITimeRecurring
    {
        public override Guid RowKey { get { return TimeRecurringKey; } set { TimeRecurringKey = value; } }
        public Guid TimeRecurringKey { get; set; }
        public int BeginDay { get; set; }
        public int EndDay { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime EndTime { get; set; }
        public int Interval { get; set; }
        public Guid TimeCycleKey { get; set; }
    }
}
