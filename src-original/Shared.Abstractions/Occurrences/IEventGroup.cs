using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventGroup : IDomainEntity<IEventGroup>
    {
        string EventGroupDescription { get; set; }
        Guid EventGroupKey { get; set; }
        string EventGroupName { get; set; }
    }
}