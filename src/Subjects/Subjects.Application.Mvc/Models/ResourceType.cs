using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class ResourceType
    {
        public ResourceType()
        {
            EventResource = new HashSet<EventResource>();
            SlotResource = new HashSet<SlotResource>();
            VentureResource = new HashSet<VentureResource>();
        }

        public int ResourceTypeId { get; set; }
        public Guid ResourceTypeKey { get; set; }
        public string ResourceTypeName { get; set; }
        public string ResourceTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<EventResource> EventResource { get; set; }
        public virtual ICollection<SlotResource> SlotResource { get; set; }
        public virtual ICollection<VentureResource> VentureResource { get; set; }
    }
}
