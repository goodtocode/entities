using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IItemGroup : IDomainModel<IItemGroup>
    {
        string ItemGroupDescription { get; set; }
        Guid ItemGroupKey { get; set; }
        string ItemGroupName { get; set; }
    }
}