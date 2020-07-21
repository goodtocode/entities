using System;

namespace GoodToCode.Subjects.Models
{
    public interface IEventAppointment
    {
        Guid AppointmentKey { get; set; }
        DateTime CreatedDate { get; set; }
        int EventAppointmentId { get; set; }
        Guid EventAppointmentKey { get; set; }
        Guid EventKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
    }
}