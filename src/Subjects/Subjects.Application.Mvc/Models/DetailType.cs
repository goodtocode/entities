using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class DetailType
    {
        public DetailType()
        {
            Detail = new HashSet<Detail>();
        }

        public int DetailTypeId { get; set; }
        public Guid DetailTypeKey { get; set; }
        public string DetailTypeName { get; set; }
        public string DetailTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<Detail> Detail { get; set; }
    }
}
