using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class Slot : DomainEntity<ISlot>, ISlot
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return SlotKey; } set { SlotKey = value; } }
        public Guid SlotKey { get; set; }
        public string SlotName { get; set; }
        public string SlotDescription { get; set; }
    }
}
