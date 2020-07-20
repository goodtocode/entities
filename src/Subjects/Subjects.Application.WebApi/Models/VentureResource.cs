using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class VentureResource
    {
        public int VentureResourceId { get; set; }
        public Guid VentureResourceKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid? ResourceTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Resource ResourceKeyNavigation { get; set; }
        public virtual ResourceType ResourceTypeKeyNavigation { get; set; }
        public virtual Venture VentureKeyNavigation { get; set; }
    }
}
