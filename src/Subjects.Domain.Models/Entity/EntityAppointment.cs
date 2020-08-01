using System;

namespace GoodToCode.Subjects.Models
{
    public class EntityAppointment : IEntityAppointment
    {
        public int EntityAppointmentId { get; set; }
        public Guid EntityAppointmentKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid AppointmentKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
