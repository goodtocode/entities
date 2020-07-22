using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public partial class Resource : IResource
    {
        public Resource()
        {
            EventResource = new HashSet<EventResource>();
            ResourceItem = new HashSet<ResourceItem>();
            ResourcePerson = new HashSet<ResourcePerson>();
            ResourceTimeRecurring = new HashSet<ResourceTimeRecurring>();
            SlotResource = new HashSet<SlotResource>();
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
        public virtual ICollection<EventResource> EventResource { get; set; }
        public virtual ICollection<ResourceItem> ResourceItem { get; set; }
        public virtual ICollection<ResourcePerson> ResourcePerson { get; set; }
        public virtual ICollection<ResourceTimeRecurring> ResourceTimeRecurring { get; set; }
        public virtual ICollection<SlotResource> SlotResource { get; set; }
        public virtual ICollection<VentureResource> VentureResource { get; set; }
    }
}
