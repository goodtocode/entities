using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateAppointment : DomainModel<IAssociateAppointment>, IAssociateAppointment
    {
        [Key]
        public Guid AssociateAppointmentKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid AppointmentKey { get; set; }
        
        
    }
}
