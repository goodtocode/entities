using System;

namespace GoodToCode.Occurrences.Models
{
    public class EventDetail
    {
        public Guid EventDetailKey { get; set; }
        public Guid EventKey { get; set; }
        public Guid DetailKey { get; set; }
    }
}
