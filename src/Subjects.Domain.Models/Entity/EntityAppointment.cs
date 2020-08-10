using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class EntityAppointment : IEntityAppointment
    {
        [Key]
        public Guid EntityAppointmentKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid AppointmentKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
