using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public class EntityAppointment
    {
        public Guid EntityAppointmentKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
