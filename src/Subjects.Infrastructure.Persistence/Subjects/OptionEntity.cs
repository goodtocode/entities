using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class OptionEntity : Option, IOption
    {
        public OptionEntity()
        {
            EntityOption = new HashSet<EntityOptionEntity>();
            VentureEntityOption = new HashSet<VentureEntityOptionEntity>();
            VentureOption = new HashSet<VentureOptionEntity>();
        }

        public virtual OptionGroupEntity OptionGroupKeyNavigation { get; set; }
        public virtual ICollection<EntityOptionEntity> EntityOption { get; set; }
        public virtual ICollection<VentureEntityOptionEntity> VentureEntityOption { get; set; }
        public virtual ICollection<VentureOptionEntity> VentureOption { get; set; }
    }
}
