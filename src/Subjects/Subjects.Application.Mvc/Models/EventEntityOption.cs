using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class EventEntityOption
    {
        public int EventEntityOptionId { get; set; }
        public Guid EventEntityOptionKey { get; set; }
        public Guid OptionKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid EntityKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Entity EntityKeyNavigation { get; set; }
        public virtual Event EventKeyNavigation { get; set; }
        public virtual Option OptionKeyNavigation { get; set; }
    }
}
