using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class VentureLocation
    {
        public int VentureLocationId { get; set; }
        public Guid VentureLocationKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual Location LocationKeyNavigation { get; set; }
        public virtual LocationType LocationTypeKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual Venture VentureKeyNavigation { get; set; }
    }
}
