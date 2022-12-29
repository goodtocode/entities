using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceItem : DomainEntity<IResourceItem>, IResourceItem
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ResourceItemKey; } set { ResourceItemKey = value; } }
        public Guid ResourceItemKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid ItemKey { get; set; }
        
        
    }
}
