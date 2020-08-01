
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class Item : IItem
    {
        public Item()
        {
            ResourceItem = new HashSet<ResourceItem>();
        }

        public int ItemId { get; set; }
        public Guid ItemKey { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Guid ItemTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual ICollection<ResourceItem> ResourceItem { get; set; }
    }
}
