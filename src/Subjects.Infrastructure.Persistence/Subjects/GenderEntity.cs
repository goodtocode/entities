using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class GenderEntity : Gender, IGender
    {
        public GenderEntity()
        {
            Person = new HashSet<PersonEntity>();
        }

        public virtual ICollection<PersonEntity> Person { get; set; }
    }
}
