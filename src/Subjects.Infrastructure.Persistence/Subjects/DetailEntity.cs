
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class DetailEntity : IDetail
    {
        public DetailEntity()
        {
            EntityDetail = new HashSet<EntityDetailEntity>();
            VentureDetail = new HashSet<VentureDetailEntity>();
        }

        public int DetailId { get; set; }
        [Key]
        public Guid DetailKey { get; set; }
        public Guid DetailTypeKey { get; set; }
        public string DetailData { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual DetailTypeEntity DetailTypeKeyNavigation { get; set; }
        public virtual ICollection<EntityDetailEntity> EntityDetail { get; set; }
        public virtual ICollection<VentureDetailEntity> VentureDetail { get; set; }
    }
}
