using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Chronology.Models
{
    public interface ISlot : IDomainModel<ISlot>
    {
        string SlotDescription { get; set; }
        Guid SlotKey { get; set; }
        string SlotName { get; set; }
    }
}