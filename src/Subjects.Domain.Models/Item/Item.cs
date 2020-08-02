
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Item : IItem
    {
        public Item()
        {
        }

        public int ItemId { get; set; }
        [Key]
        public Guid ItemKey { get; set; }
        public string ItemName { get; set; }
        public string ItemDescription { get; set; }
        public Guid ItemTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
