using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public interface IItem
    {
        DateTime CreatedDate { get; set; }
        string ItemDescription { get; set; }
        int ItemId { get; set; }
        Guid ItemKey { get; set; }
        string ItemName { get; set; }
        Guid ItemTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
    }
}