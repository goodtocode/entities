using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class VentureEntityOption
    {
        public int VentureEntityOptionId { get; set; }
        public Guid VentureEntityOptionKey { get; set; }
        public Guid OptionKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid EntityKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Entity EntityKeyNavigation { get; set; }
        public virtual Option OptionKeyNavigation { get; set; }
        public virtual Venture VentureKeyNavigation { get; set; }
    }
}
