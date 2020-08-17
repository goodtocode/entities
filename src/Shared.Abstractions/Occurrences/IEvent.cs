using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEvent : IDomainModel<IEvent>
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