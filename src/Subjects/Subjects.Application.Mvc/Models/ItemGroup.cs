using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class ItemGroup
    {
        public ItemGroup()
        {
            ItemType = new HashSet<ItemType>();
        }

        public int ItemGroupId { get; set; }
        public Guid ItemGroupKey { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemGroupDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<ItemType> ItemType { get; set; }
    }
}
