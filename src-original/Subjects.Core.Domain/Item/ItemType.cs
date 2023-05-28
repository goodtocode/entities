using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ItemType : DomainEntity<IItemType>, IItemType
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ItemTypeKey; } set { ItemTypeKey = value; } }
        public Guid ItemTypeKey { get; set; }
        public Guid ItemGroupKey { get; set; }
        public string ItemTypeName { get; set; }
        public string ItemTypeDescription { get; set; }
    }
}
