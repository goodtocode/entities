using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public partial class Detail : IDetail
    {
        public Detail()
        {
            EntityDetail = new HashSet<EntityDetail>();
            EventDetail = new HashSet<EventDetail>();
            VentureDetail = new HashSet<VentureDetail>();
        }

        public int DetailId { get; set; }
        public Guid DetailKey { get; set; }
        public Guid DetailTypeKey { get; set; }
        public string DetailData { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual DetailType DetailTypeKeyNavigation { get; set; }
        public virtual ICollection<EntityDetail> EntityDetail { get; set; }
        public virtual ICollection<EventDetail> EventDetail { get; set; }
        public virtual ICollection<VentureDetail> VentureDetail { get; set; }
    }
}
