using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceItem : DomainModel<IResourceItem>, IResourceItem
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ResourceItemKey; } set { ResourceItemKey = value; } }
        public Guid ResourceItemKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid ItemKey { get; set; }
        
        
    }
}
