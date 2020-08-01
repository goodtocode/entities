using System;

namespace GoodToCode.Subjects.Models
{
    public class VentureLocation : IVentureLocation
    {
        public int VentureLocationId { get; set; }
        public Guid VentureLocationKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
