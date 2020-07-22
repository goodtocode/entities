using System;

namespace GoodToCode.Shared.Models
{
    public interface IResourceItem
    {
        DateTime CreatedDate { get; set; }
        Guid ItemKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        int ResourceItemId { get; set; }
        Guid ResourceItemKey { get; set; }
        Guid ResourceKey { get; set; }
    }
}