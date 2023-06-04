
using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceType : DomainEntity<IResourceType>, IResourceType
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return ResourceTypeKey; } set { ResourceTypeKey = value; } }
        public Guid ResourceTypeKey { get; set; }
        public string ResourceTypeName { get; set; }
        public string ResourceTypeDescription { get; set; }
        
        
    }
}
