using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class EntityEntity : Entity, IEntity
    {
        public EntityEntity()
        {
            EntityAppointment = new HashSet<EntityAppointmentEntity>();
            EntityDetail = new HashSet<EntityDetailEntity>();
            EntityLocation = new HashSet<EntityLocationEntity>();
            EntityTimeRecurring = new HashSet<EntityTimeRecurringEntity>();
            VentureEntityOption = new HashSet<VentureEntityOptionEntity>();
        }
        public virtual BusinessEntity Business { get; set; }
        public virtual GovernmentEntity Government { get; set; }
        public virtual PersonEntity Person { get; set; }
        public virtual ICollection<EntityAppointmentEntity> EntityAppointment { get; set; }
        public virtual ICollection<EntityDetailEntity> EntityDetail { get; set; }
        public virtual ICollection<EntityLocationEntity> EntityLocation { get; set; }
        public virtual ICollection<EntityTimeRecurringEntity> EntityTimeRecurring { get; set; }
        public virtual ICollection<VentureEntityOptionEntity> VentureEntityOption { get; set; }
    }
}
