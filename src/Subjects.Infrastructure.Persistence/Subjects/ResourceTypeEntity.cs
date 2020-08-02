using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class ResourceTypeEntity : ResourceType, IResourceType
    {
        public ResourceTypeEntity()
        {
            VentureResource = new HashSet<VentureResourceEntity>();
        }
        public virtual ICollection<VentureResourceEntity> VentureResource { get; set; }
    }
}
