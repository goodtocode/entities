
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourceType : IResourceType
    {
        public ResourceType()
        {
        }

        public int ResourceTypeId { get; set; }
        [Key]
        public Guid ResourceTypeKey { get; set; }
        public string ResourceTypeName { get; set; }
        public string ResourceTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
