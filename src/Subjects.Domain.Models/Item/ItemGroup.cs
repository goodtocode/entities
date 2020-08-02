
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ItemGroup : IItemGroup
    {
        [Key]
        public Guid ItemGroupKey { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemGroupDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
