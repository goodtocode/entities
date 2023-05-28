using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotLocation : IDomainEntity<ISlotLocation>
    {
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        Guid SlotKey { get; set; }
        Guid SlotLocationKey { get; set; }
    }
}