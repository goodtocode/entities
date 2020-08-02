using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class ItemGroupEntity : ItemGroup, IItemGroup
    {
        public ItemGroupEntity()
        {
            ItemType = new HashSet<ItemTypeEntity>();
        }

        public virtual ICollection<ItemTypeEntity> ItemType { get; set; }
    }
}
