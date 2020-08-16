using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Chronology.Models
{
    public class Slot : DomainModel<ISlot>, ISlot
    {
        public Guid SlotKey { get; set; }
        public string SlotName { get; set; }
        public string SlotDescription { get; set; }
    }
}
