
using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceType : DomainModel<IResourceType>, IResourceType
    {
        public override Guid RowKey { get { return ResourceTypeKey; } set { ResourceTypeKey = value; } }
        public Guid ResourceTypeKey { get; set; }
        public string ResourceTypeName { get; set; }
        public string ResourceTypeDescription { get; set; }
        
        
    }
}
