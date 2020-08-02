using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventAppointment
    {
        Guid AppointmentKey { get; set; }
        DateTime CreatedDate { get; set; }
        Guid EventAppointmentKey { get; set; }
        Guid EventKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
    }
}