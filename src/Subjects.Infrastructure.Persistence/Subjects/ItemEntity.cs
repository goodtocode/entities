using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class ItemEntity : Item, IItem
    {
        public ItemEntity()
        {
            ResourceItem = new HashSet<ResourceItemEntity>();
        }

        public virtual RecordStateEntity RecordStateKeyNavigation { get; set; }
        public virtual ICollection<ResourceItemEntity> ResourceItem { get; set; }
    }
}
