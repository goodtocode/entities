using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ItemGroup : DomainModel<IItemGroup>, IItemGroup
    {
        public override Guid RowKey { get { return ItemGroupKey; } set { ItemGroupKey = value; } }
        public Guid ItemGroupKey { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemGroupDescription { get; set; }
    }
}
