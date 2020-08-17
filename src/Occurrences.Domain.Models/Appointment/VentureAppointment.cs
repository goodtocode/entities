using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public class VentureAppointment : DomainModel<IVentureAppointment>, IVentureAppointment
    {
        public Guid VentureAppointmentKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
