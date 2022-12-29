using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class SlotResource : DomainEntity<ISlotResource>, ISlotResource
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return SlotResourceKey; } set { SlotResourceKey = value; } }
        public Guid SlotResourceKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid? ResourceTypeKey { get; set; }        
    }
}
