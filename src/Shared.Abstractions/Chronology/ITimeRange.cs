using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public interface ITimeRange
    {
        DateTime BeginDate { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime EndDate { get; set; }
        int TimeRangeId { get; set; }
        Guid TimeRangeKey { get; set; }
    }
}