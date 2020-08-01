
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class ResourceType : IResourceType
    {
        public ResourceType()
        {
            VentureResource = new HashSet<VentureResource>();
        }

        public int ResourceTypeId { get; set; }
        public Guid ResourceTypeKey { get; set; }
        public string ResourceTypeName { get; set; }
        public string ResourceTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public virtual ICollection<VentureResource> VentureResource { get; set; }
    }
}
