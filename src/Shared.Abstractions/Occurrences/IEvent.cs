using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEvent : IDomainEntity<IEvent>
    {
        Guid EventCreatorKey { get; set; }
        string EventDescription { get; set; }
        Guid EventGroupKey { get; set; }
        Guid EventKey { get; set; }
        string EventName { get; set; }
        string EventSlogan { get; set; }
        Guid EventTypeKey { get; set; }
    }
}