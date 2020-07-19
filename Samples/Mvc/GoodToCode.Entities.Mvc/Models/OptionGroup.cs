using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class OptionGroup
    {
        public OptionGroup()
        {
            Option = new HashSet<Option>();
        }

        public int OptionGroupId { get; set; }
        public Guid OptionGroupKey { get; set; }
        public string OptionGroupName { get; set; }
        public string OptionGroupDescription { get; set; }
        public string OptionGroupCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Option> Option { get; set; }
    }
}
