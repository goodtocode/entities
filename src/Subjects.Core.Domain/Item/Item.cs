
using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Item : DomainEntity<IItem>, IItem
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ItemKey; } set { ItemKey = value; } }
        public Guid ItemKey { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Guid ItemTypeKey { get; set; }
    }
}
