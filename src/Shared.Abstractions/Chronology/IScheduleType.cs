using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IScheduleType : IDomainModel<IScheduleType>
    {
        string ScheduleTypeDescription { get; set; }
        Guid ScheduleTypeKey { get; set; }
        string ScheduleTypeName { get; set; }
    }
}