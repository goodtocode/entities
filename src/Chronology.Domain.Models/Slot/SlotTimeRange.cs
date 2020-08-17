using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Chronology.Models
{
    public class SlotTimeRange : DomainModel<ISlotTimeRange>, ISlotTimeRange
    {
        [Key]
        public Guid SlotTimeRangeKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid TimeRangeKey { get; set; }
        public Guid? TimeTypeKey { get; set; }
    }
}
