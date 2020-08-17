using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public class VentureAppointment : DomainModel<IAppointmentVenture>, IAppointmentVenture
    {
        public Guid AppointmentVentureKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
