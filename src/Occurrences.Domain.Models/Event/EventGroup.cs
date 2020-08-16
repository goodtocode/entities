using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public class EventGroup
    {
        public Guid EventGroupKey { get; set; }
        public string EventGroupName { get; set; }
        public string EventGroupDescription { get; set; }
    }
}
