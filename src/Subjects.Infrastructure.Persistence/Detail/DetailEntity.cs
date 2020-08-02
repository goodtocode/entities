using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class DetailEntity : Detail, IDetail
    {
        public DetailEntity()
        {
            EntityDetail = new HashSet<EntityDetailEntity>();
            VentureDetail = new HashSet<VentureDetailEntity>();
        }
        public virtual DetailTypeEntity DetailTypeKeyNavigation { get; set; }
        public virtual ICollection<EntityDetailEntity> EntityDetail { get; set; }
        public virtual ICollection<VentureDetailEntity> VentureDetail { get; set; }
    }
}
