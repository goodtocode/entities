using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IItemType : IDomainEntity<IItemType>
    {
        Guid ItemGroupKey { get; set; }
        string ItemTypeDescription { get; set; }
        Guid ItemTypeKey { get; set; }
        string ItemTypeName { get; set; }
        
    }
}