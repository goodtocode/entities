using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public class TimeRange : DomainModel<ITimeRange>, ITimeRange
    {
        public Guid TimeRangeKey { get; set; }
        public DateTime BeginDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
