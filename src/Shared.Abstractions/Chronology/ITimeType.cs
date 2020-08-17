using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public interface ITimeType : IDomainModel<ITimeType>
    {
        
        
        int TimeBehavior { get; set; }
        string TimeTypeDescription { get; set; }
        Guid TimeTypeKey { get; set; }
        string TimeTypeName { get; set; }
    }
}