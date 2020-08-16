using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureAppointment : DomainModel<IVentureAppointment>, IVentureAppointment
    {
        [Key]
        public Guid VentureAppointmentKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid AppointmentKey { get; set; }
        
        
    }
}
