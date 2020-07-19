using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class EntityOption
    {
        public int EntityOptionId { get; set; }
        public Guid EntityOptionKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid OptionKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Option OptionKeyNavigation { get; set; }
    }
}
