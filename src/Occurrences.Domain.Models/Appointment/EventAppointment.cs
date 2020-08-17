using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Occurrences.Models
{
    public class EventAppointment : DomainModel<IEventAppointment>, IEventAppointment
    {
        [Key]
        public Guid AppointmentEventKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid AppointmentKey { get; set; }
    }
}
