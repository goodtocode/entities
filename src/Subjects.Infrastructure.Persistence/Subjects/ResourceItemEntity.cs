
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class ResourceItemEntity : ResourceItem, IResourceItem
    {
        public virtual ItemEntity ItemKeyNavigation { get; set; }
        public virtual RecordStateEntity RecordStateKeyNavigation { get; set; }
        public virtual ResourceEntity ResourceKeyNavigation { get; set; }
    }
}
