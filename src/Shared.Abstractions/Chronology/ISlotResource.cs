using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlotResource : IDomainModel<ISlotResource>
    {
        Guid ResourceKey { get; set; }
        Guid? ResourceTypeKey { get; set; }
        Guid SlotKey { get; set; }
        Guid SlotResourceKey { get; set; }
    }
}