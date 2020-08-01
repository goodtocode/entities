
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class Resource : IResource
    {
        public Resource()
        {
            ResourceItem = new HashSet<ResourceItem>();
            ResourcePerson = new HashSet<ResourcePerson>();
            ResourceTimeRecurring = new HashSet<ResourceTimeRecurring>();
            VentureResource = new HashSet<VentureResource>();
        }

        public int ResourceId { get; set; }
        public Guid ResourceKey { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual ICollection<ResourceItem> ResourceItem { get; set; }
        public virtual ICollection<ResourcePerson> ResourcePerson { get; set; }
        public virtual ICollection<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual ICollection<VentureResource> VentureResource { get; set; }
    }
}
