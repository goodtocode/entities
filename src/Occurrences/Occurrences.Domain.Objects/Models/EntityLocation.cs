using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class EntityLocation : IEntityLocation
    {
        public int EntityLocationId { get; set; }
        public Guid EntityLocationKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Entity EntityKeyNavigation { get; set; }
        public virtual Location LocationKeyNavigation { get; set; }
        public virtual LocationType LocationTypeKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
    }
}
