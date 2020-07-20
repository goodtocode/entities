using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class EventOption : IEventOption
    {
        public int EventOptionId { get; set; }
        public Guid EventOptionKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid OptionKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Event EventKeyNavigation { get; set; }
        public virtual Option OptionKeyNavigation { get; set; }
    }
}
