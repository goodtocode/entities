using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class EventLocation
    {
        public int EventLocationId { get; set; }
        public Guid EventLocationKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Event EventKeyNavigation { get; set; }
        public virtual Location LocationKeyNavigation { get; set; }
        public virtual LocationType LocationTypeKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
    }
}
