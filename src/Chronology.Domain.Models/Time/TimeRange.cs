using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class TimeRange : DomainModel<ITimeRange>, ITimeRange
    {
        public override Guid RowKey { get { return TimeRangeKey; } set { TimeRangeKey = value; } }
        public Guid TimeRangeKey { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
