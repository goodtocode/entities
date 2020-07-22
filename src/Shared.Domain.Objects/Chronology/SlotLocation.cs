using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public partial class SlotLocation : ISlotLocation
    {
        public SlotLocation()
        {
            Appointment = new HashSet<Appointment>();
        }

        public int SlotLocationId { get; set; }
        public Guid SlotLocationKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Location LocationKeyNavigation { get; set; }
        public virtual LocationType LocationTypeKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Slot SlotKeyNavigation { get; set; }
        public virtual ICollection<Appointment> Appointment { get; set; }
    }
}
