using System;

namespace GoodToCode.Subjects.Models
{
    public class ItemTypeEntity : ItemType, IItemType
    {
        public virtual ItemGroupEntity ItemGroupKeyNavigation { get; set; }
    }
}
