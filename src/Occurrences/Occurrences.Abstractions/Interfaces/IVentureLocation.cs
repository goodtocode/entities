using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureLocation
    {
        DateTime CreatedDate { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid VentureKey { get; set; }
        int VentureLocationId { get; set; }
        Guid VentureLocationKey { get; set; }
    }
}