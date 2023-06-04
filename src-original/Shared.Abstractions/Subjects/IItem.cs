using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IItem : IDomainEntity<IItem>
    {
        string ItemDescription { get; set; }
        Guid ItemKey { get; set; }
        string ItemName { get; set; }
        Guid ItemTypeKey { get; set; }
    }
}