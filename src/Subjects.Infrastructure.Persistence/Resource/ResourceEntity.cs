using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class ResourceEntity : Resource, IResource
    {
        public ResourceEntity()
        {
            ResourceItem = new HashSet<ResourceItemEntity>();
            ResourcePerson = new HashSet<ResourcePersonEntity>();
            ResourceTimeRecurring = new HashSet<ResourceTimeRecurringEntity>();
            VentureResource = new HashSet<VentureResourceEntity>();
        }

        
        public virtual ICollection<ResourceItemEntity> ResourceItem { get; set; }
        public virtual ICollection<ResourcePersonEntity> ResourcePerson { get; set; }
        public virtual ICollection<ResourceTimeRecurringEntity> ResourceTimeRecurring { get; set; }
        public virtual ICollection<VentureResourceEntity> VentureResource { get; set; }
    }
}
