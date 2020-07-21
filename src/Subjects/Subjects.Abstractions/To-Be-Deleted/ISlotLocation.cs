using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface ISlotLocation
    {
        DateTime CreatedDate { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid SlotKey { get; set; }
        int SlotLocationId { get; set; }
        Guid SlotLocationKey { get; set; }
    }
}