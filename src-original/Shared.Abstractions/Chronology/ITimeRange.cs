using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ITimeRange : IDomainEntity<ITimeRange>
    {
        DateTime BeginDate { get; set; }
        
        DateTime EndDate { get; set; }
        Guid TimeRangeKey { get; set; }
    }
}