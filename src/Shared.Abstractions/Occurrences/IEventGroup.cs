using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventGroup : IDomainModel<IEventGroup>
    {
        string EventGroupDescription { get; set; }
        Guid EventGroupKey { get; set; }
        string EventGroupName { get; set; }
    }
}