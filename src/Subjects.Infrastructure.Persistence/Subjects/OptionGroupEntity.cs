using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class OptionGroupEntity : OptionGroup, IOptionGroup
    {
        public OptionGroupEntity()
        {
            Option = new HashSet<OptionEntity>();
        }

        public virtual ICollection<OptionEntity> Option { get; set; }
    }
}
