using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class Option
    {
        public Option()
        {
            EntityOption = new HashSet<EntityOption>();
            EventEntityOption = new HashSet<EventEntityOption>();
            EventOption = new HashSet<EventOption>();
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
        public virtual ICollection<EventEntityOption> EventEntityOption { get; set; }
        public virtual ICollection<EventOption> EventOption { get; set; }
        public virtual ICollection<VentureEntityOption> VentureEntityOption { get; set; }
        public virtual ICollection<VentureOption> VentureOption { get; set; }
    }
}
