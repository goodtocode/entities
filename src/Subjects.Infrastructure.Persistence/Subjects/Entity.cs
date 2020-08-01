
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class Entity : IEntity
    {
        public Entity()
        {
            EntityAppointment = new HashSet<EntityAppointment>();
            EntityDetail = new HashSet<EntityDetail>();
            EntityLocation = new HashSet<EntityLocation>();
            EntityTimeRecurring = new HashSet<EntityTimeRecurring>();
            VentureEntityOption = new HashSet<VentureEntityOption>();
        }

        public int EntityId { get; set; }
        public Guid EntityKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Business Business { get; set; }
        public virtual Government Government { get; set; }
        public virtual Person Person { get; set; }
        public virtual ICollection<EntityAppointment> EntityAppointment { get; set; }
        public virtual ICollection<EntityDetail> EntityDetail { get; set; }
        public virtual ICollection<EntityLocation> EntityLocation { get; set; }
        public virtual ICollection<EntityTimeRecurring> EntityTimeRecurring { get; set; }
        public virtual ICollection<VentureEntityOption> VentureEntityOption { get; set; }
    }
}
