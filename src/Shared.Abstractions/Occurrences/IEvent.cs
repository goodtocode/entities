using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public interface IEvent
    {
        DateTime CreatedDate { get; set; }
        Guid EventCreatorKey { get; set; }
        string EventDescription { get; set; }
        Guid EventGroupKey { get; set; }
        Guid EventKey { get; set; }
        string EventName { get; set; }
        string EventSlogan { get; set; }
        Guid EventTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
    }
}