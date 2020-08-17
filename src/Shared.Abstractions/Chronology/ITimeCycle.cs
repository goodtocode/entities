using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ITimeCycle : IDomainModel<ITimeCycle>
    {
        
        int Days { get; set; }
        int Interval { get; set; }
        
        string TimeCycleDescription { get; set; }
        Guid TimeCycleKey { get; set; }
        string TimeCycleName { get; set; }
    }
}