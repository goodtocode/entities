using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventType
    {
        DateTime CreatedDate { get; set; }
        Guid EventGroupKey { get; set; }
        string EventTypeDescription { get; set; }
        Guid EventTypeKey { get; set; }
        string EventTypeName { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}