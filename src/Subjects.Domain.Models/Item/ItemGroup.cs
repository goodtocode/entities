using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ItemGroup : DomainModel<IItemGroup>, IItemGroup
    {
        [Key]
        public Guid ItemGroupKey { get; set; }
        public string ItemGroupName { get; set; }
        public string ItemGroupDescription { get; set; }
    }
}
