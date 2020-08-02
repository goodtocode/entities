using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class PersonEntity : Person, IPerson
    {
        public PersonEntity()
        {
            ResourcePerson = new HashSet<ResourcePersonEntity>();
        }
        public virtual GenderEntity Gender { get; set; }
        public virtual EntityEntity PersonKeyNavigation { get; set; }
        public virtual ICollection<ResourcePersonEntity> ResourcePerson { get; set; }
    }
}
