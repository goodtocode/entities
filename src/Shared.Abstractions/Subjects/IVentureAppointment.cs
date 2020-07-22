using System;

namespace GoodToCode.Shared.Models
{
    public interface IVentureAppointment
    {
        Guid AppointmentKey { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        int VentureAppointmentId { get; set; }
        Guid VentureAppointmentKey { get; set; }
        Guid VentureKey { get; set; }
    }
}