using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlot : IDomainEntity<ISlot>
    {
        string SlotDescription { get; set; }
        Guid SlotKey { get; set; }
        string SlotName { get; set; }
    }
}