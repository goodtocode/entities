using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IResourceItem : IDomainModel<IResourceItem>
    {
        Guid ItemKey { get; set; }
        Guid ResourceItemKey { get; set; }
        Guid ResourceKey { get; set; }
    }
}