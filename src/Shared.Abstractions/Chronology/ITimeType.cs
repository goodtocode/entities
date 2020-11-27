using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public interface ITimeType : IDomainEntity<ITimeType>
    {
        
        
        int TimeBehavior { get; set; }
        string TimeTypeDescription { get; set; }
        Guid TimeTypeKey { get; set; }
        string TimeTypeName { get; set; }
    }
}