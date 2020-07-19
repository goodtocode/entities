using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.WebApi1.Models
{
    public partial class LocationType
    {
        public LocationType()
        {
            EntityLocation = new HashSet<EntityLocation>();
            EventLocation = new HashSet<EventLocation>();
            SlotLocation = new HashSet<SlotLocation>();
            VentureLocation = new HashSet<VentureLocation>();
        }

        public int LocationTypeId { get; set; }
        public Guid LocationTypeKey { get; set; }
        public string LocationTypeName { get; set; }
        public string LocationTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<EntityLocation> EntityLocation { get; set; }
        public virtual ICollection<EventLocation> EventLocation { get; set; }
        public virtual ICollection<SlotLocation> SlotLocation { get; set; }
        public virtual ICollection<VentureLocation> VentureLocation { get; set; }
    }
}
