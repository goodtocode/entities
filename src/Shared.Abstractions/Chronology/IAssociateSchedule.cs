using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface IAssociateSchedule : IDomainModel<IAssociateSchedule>
    {
        Guid ScheduleKey { get; set; }
        Guid? ScheduleTypeKey { get; set; }
        Guid AssociateKey { get; set; }
        Guid AssociateScheduleKey { get; set; }
    }
}