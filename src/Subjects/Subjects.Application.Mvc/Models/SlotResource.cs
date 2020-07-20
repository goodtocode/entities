using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class SlotResource
    {
        public SlotResource()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int SlotResourceId { get; set; }
        public Guid SlotResourceKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid? ResourceTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Resource ResourceKeyNavigation { get; set; }
        public virtual ResourceType ResourceTypeKeyNavigation { get; set; }
        public virtual Slot SlotKeyNavigation { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
