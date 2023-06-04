using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IItemGroup : IDomainEntity<IItemGroup>
    {
        string ItemGroupDescription { get; set; }
        Guid ItemGroupKey { get; set; }
        string ItemGroupName { get; set; }
    }
}