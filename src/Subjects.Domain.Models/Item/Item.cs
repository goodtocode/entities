
using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Item : DomainModel<IItem>, IItem
    {
        [Key]
        public Guid ItemKey { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Guid ItemTypeKey { get; set; }
    }
}
