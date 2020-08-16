using System;
using System.Collections.Generic;

namespace GoodToCode.Occurrences.Models
{
    public class EventResource
    {
        public Guid EventResourceKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid? ResourceTypeKey { get; set; }
    }
}
