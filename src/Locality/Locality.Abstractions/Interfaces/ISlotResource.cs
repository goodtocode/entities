using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface ISlotResource
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid? ResourceTypeKey { get; set; }
        Guid SlotKey { get; set; }
        int SlotResourceId { get; set; }
        Guid SlotResourceKey { get; set; }
    }
}