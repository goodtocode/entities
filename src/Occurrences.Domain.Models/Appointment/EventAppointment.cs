using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventAppointment : DomainEntity<IEventAppointment>, IEventAppointment
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return AppointmentEventKey; } set { AppointmentEventKey = value; } }
        public Guid AppointmentEventKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
