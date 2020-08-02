using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class ItemEntity : Item, IItem
    {
        public ItemEntity()
        {
            ResourceItem = new HashSet<ResourceItemEntity>();
        }

        
        public virtual ICollection<ResourceItemEntity> ResourceItem { get; set; }
    }
}
