using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IAssociateSchedule : IDomainEntity<IAssociateSchedule>
    {
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid AssociateKey { get; set; }
        Guid AssociateScheduleKey { get; set; }
    }
}