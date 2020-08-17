using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ITimeRange : IDomainModel<ITimeRange>
    {
        DateTime BeginDate { get; set; }
        
        DateTime EndDate { get; set; }
        Guid TimeRangeKey { get; set; }
    }
}