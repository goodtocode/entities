using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public class VentureAppointment
    {
        public Guid VentureAppointmentKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
