using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventType : IDomainEntity<IEventType>
    {
        Guid EventGroupKey { get; set; }
        string EventTypeDescription { get; set; }
        Guid EventTypeKey { get; set; }
        string EventTypeName { get; set; }
    }
}