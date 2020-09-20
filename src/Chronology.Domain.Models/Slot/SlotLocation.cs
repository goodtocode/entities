using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class SlotLocation : DomainModel<ISlotLocation>, ISlotLocation
    {
        public override Guid RowKey { get { return SlotLocationKey; } set { SlotLocationKey = value; } }
        public override string PartitionKey { get; set; } = "Default";
        public Guid SlotLocationKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
    }
}
