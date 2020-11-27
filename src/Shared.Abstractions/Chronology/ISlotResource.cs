using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotResource : IDomainEntity<ISlotResource>
    {
        Guid ResourceKey { get; set; }
        Guid? ResourceTypeKey { get; set; }
        Guid SlotKey { get; set; }
        Guid SlotResourceKey { get; set; }
    }
}