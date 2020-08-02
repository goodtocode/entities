
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceType : IResourceType
    {
        [Key]
        public int ResourceTypeId { get; set; }
        public Guid ResourceTypeKey { get; set; }
        public string ResourceTypeName { get; set; }
        public string ResourceTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
