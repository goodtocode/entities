using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class ResourceItem : IResourceItem
    {
        public int ResourceItemId { get; set; }
        public Guid ResourceItemKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid ItemKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Item ItemKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Resource ResourceKeyNavigation { get; set; }
    }
}
