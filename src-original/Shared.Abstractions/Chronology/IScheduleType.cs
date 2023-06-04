using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IScheduleType : IDomainEntity<IScheduleType>
    {
        string ScheduleTypeDescription { get; set; }
        Guid ScheduleTypeKey { get; set; }
        string ScheduleTypeName { get; set; }
    }
}