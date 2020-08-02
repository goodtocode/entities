using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public interface ITimeRange
    {
        DateTime BeginDate { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime EndDate { get; set; }
        Guid TimeRangeKey { get; set; }
    }
}