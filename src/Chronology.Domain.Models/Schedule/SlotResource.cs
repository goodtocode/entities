using System;

namespace GoodToCode.Chronology.Models
{
    public class SlotResource
    {
        public Guid SlotResourceKey { get; set; }
        public Guid SlotKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid? ResourceTypeKey { get; set; }        
    }
}
