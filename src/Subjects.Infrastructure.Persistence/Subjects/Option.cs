
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public class Option : IOption
    {
        public Option()
        {
            EntityOption = new HashSet<EntityOption>();
            VentureEntityOption = new HashSet<VentureEntityOption>();
            VentureOption = new HashSet<VentureOption>();
        }

        public int OptionId { get; set; }
        public Guid OptionKey { get; set; }
        public Guid OptionGroupKey { get; set; }
        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
        public string OptionCode { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual OptionGroup OptionGroupKeyNavigation { get; set; }
        public virtual ICollection<EntityOption> EntityOption { get; set; }
        public virtual ICollection<VentureEntityOption> VentureEntityOption { get; set; }
        public virtual ICollection<VentureOption> VentureOption { get; set; }
    }
}
