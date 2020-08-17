using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotLocation : IDomainModel<ISlotLocation>
    {
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        Guid SlotKey { get; set; }
        Guid SlotLocationKey { get; set; }
    }
}