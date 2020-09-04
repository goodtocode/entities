
using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Item : DomainModel<IItem>, IItem
    {
        public override Guid RowKey { get { return ItemKey; } protected set { ItemKey = value; } }
        public Guid ItemKey { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Guid ItemTypeKey { get; set; }
    }
}
