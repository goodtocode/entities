using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public partial class Location : ILocation
    {
        public Location()
        {
            EntityLocation = new HashSet<EntityLocation>();
            EventLocation = new HashSet<EventLocation>();
            LocationArea = new HashSet<LocationArea>();
            LocationTimeRecurring = new HashSet<LocationTimeRecurring>();
            SlotLocation = new HashSet<SlotLocation>();
            VentureLocation = new HashSet<VentureLocation>();
        }

        public int LocationId { get; set; }
        public Guid LocationKey { get; set; }
        public string LocationName { get; set; }
        public string LocationDescription { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual ICollection<EntityLocation> EntityLocation { get; set; }
        public virtual ICollection<EventLocation> EventLocation { get; set; }
        public virtual ICollection<LocationArea> LocationArea { get; set; }
        public virtual ICollection<LocationTimeRecurring> LocationTimeRecurring { get; set; }
        public virtual ICollection<SlotLocation> SlotLocation { get; set; }
        public virtual ICollection<VentureLocation> VentureLocation { get; set; }
    }
}
