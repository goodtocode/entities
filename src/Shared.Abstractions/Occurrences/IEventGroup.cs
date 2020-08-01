using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventGroup
    {
        DateTime CreatedDate { get; set; }
        string EventGroupDescription { get; set; }
        int EventGroupId { get; set; }
        Guid EventGroupKey { get; set; }
        string EventGroupName { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}