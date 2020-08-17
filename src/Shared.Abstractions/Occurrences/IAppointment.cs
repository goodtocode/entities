using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IAppointment : IDomainModel<IAppointment>
    {
        string AppointmentDescription { get; set; }
        Guid AppointmentKey { get; set; }
        string AppointmentName { get; set; }
        Guid? SlotLocationKey { get; set; }
        Guid? SlotResourceKey { get; set; }
        Guid TimeRangeKey { get; set; }
    }
}