
using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceType : DomainModel<IResourceType>, IResourceType
    {
        [Key]
        public Guid ResourceTypeKey { get; set; }
        public string ResourceTypeName { get; set; }
        public string ResourceTypeDescription { get; set; }
        
        
    }
}
