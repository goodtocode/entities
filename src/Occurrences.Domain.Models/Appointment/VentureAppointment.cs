using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class VentureAppointment : DomainEntity<IVentureAppointment>, IVentureAppointment
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return VentureAppointmentKey; } set { VentureAppointmentKey = value; } }
        public Guid VentureAppointmentKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
