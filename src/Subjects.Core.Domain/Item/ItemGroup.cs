using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ItemGroup : DomainEntity<IItemGroup>, IItemGroup
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ItemGroupKey; } set { ItemGroupKey = value; } }
        public Guid ItemGroupKey { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemGroupDescription { get; set; }
    }
}
