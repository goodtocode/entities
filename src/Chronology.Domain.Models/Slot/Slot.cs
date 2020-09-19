using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class Slot : DomainModel<ISlot>, ISlot
    {
        public override Guid RowKey { get { return SlotKey; } set { SlotKey = value; } }
        public Guid SlotKey { get; set; }
        public string SlotName { get; set; }
        public string SlotDescription { get; set; }
    }
}
