using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class SlotLocation : DomainModel<ISlotLocation>, ISlotLocation
    {
        [Key]
        public Guid SlotLocationKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
    }
}
