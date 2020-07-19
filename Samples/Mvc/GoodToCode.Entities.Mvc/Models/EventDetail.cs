using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class EventDetail
    {
        public int EventDetailId { get; set; }
        public Guid EventDetailKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid DetailKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Detail DetailKeyNavigation { get; set; }
        public virtual Event EventKeyNavigation { get; set; }
    }
}
