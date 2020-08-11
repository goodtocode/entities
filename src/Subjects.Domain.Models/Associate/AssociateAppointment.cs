using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateAppointment : IAssociateAppointment
    {
        [Key]
        public Guid AssociateAppointmentKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid AppointmentKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
