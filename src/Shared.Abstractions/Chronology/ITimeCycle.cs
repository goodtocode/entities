using System;
using System.Collections.Generic;

namespace GoodToCode.Chronology.Models
{
    public interface ITimeCycle
    {
        DateTime CreatedDate { get; set; }
        int Days { get; set; }
        int Interval { get; set; }
        DateTime ModifiedDate { get; set; }
        string TimeCycleDescription { get; set; }
        int TimeCycleId { get; set; }
        Guid TimeCycleKey { get; set; }
        string TimeCycleName { get; set; }
    }
}