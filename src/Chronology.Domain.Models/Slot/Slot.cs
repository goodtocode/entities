using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class Slot : DomainModel<ISlot>, ISlot
    {
        [Key]
        public Guid SlotKey { get; set; }
        public string SlotName { get; set; }
        public string SlotDescription { get; set; }
    }
}
