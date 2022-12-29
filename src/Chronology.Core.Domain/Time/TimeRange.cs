using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class TimeRange : DomainEntity<ITimeRange>, ITimeRange
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return TimeRangeKey; } set { TimeRangeKey = value; } }
        public Guid TimeRangeKey { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
