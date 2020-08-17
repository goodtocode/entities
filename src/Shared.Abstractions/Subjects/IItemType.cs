using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IItemType : IDomainModel<IItemType>
    {
        Guid ItemGroupKey { get; set; }
        string ItemTypeDescription { get; set; }
        Guid ItemTypeKey { get; set; }
        string ItemTypeName { get; set; }
        
    }
}