using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceItem : DomainModel<IResourceItem>, IResourceItem
    {
        [Key]
        public Guid ResourceItemKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid ItemKey { get; set; }
        
        
    }
}
