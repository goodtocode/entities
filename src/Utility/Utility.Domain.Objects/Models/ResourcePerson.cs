using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class ResourcePerson : IResourcePerson
    {
        public int ResourcePersonId { get; set; }
        public Guid ResourcePersonKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid PersonKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Person PersonKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Resource ResourceKeyNavigation { get; set; }
    }
}
