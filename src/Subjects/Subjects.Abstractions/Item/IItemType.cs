using System;

namespace GoodToCode.Subjects.Models
{
    public interface IItemType
    {
        DateTime CreatedDate { get; set; }
        Guid ItemGroupKey { get; set; }
        string ItemTypeDescription { get; set; }
        int ItemTypeId { get; set; }
        Guid ItemTypeKey { get; set; }
        string ItemTypeName { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}