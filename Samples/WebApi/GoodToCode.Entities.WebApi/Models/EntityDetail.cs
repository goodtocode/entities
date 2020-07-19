using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class EntityDetail
    {
        public int EntityDetailId { get; set; }
        public Guid EntityDetailKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid DetailKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Detail DetailKeyNavigation { get; set; }
        public virtual Entity EntityKeyNavigation { get; set; }
    }
}
