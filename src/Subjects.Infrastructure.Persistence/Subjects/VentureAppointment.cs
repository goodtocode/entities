
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class VentureAppointment : IVentureAppointment
    {
        public int VentureAppointmentId { get; set; }
        public Guid VentureAppointmentKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid AppointmentKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Venture VentureKeyNavigation { get; set; }
    }
}
