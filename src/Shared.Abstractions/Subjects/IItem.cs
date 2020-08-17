using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IItem : IDomainModel<IItem>
    {
        string ItemDescription { get; set; }
        Guid ItemKey { get; set; }
        string ItemName { get; set; }
        Guid ItemTypeKey { get; set; }
    }
}