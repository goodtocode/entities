using System;

namespace GoodToCode.Subjects.Models
{
    public interface IResourceItem
    {
        DateTime CreatedDate { get; set; }
        Guid ItemKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
        Guid ResourceItemKey { get; set; }
        Guid ResourceKey { get; set; }
    }
}