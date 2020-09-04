using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class VentureAppointment : DomainModel<IVentureAppointment>, IVentureAppointment
    {
        public override Guid RowKey { get { return VentureAppointmentKey; } protected set { VentureAppointmentKey = value; } }
        public Guid VentureAppointmentKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
