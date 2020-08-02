using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventDetail
    {
        DateTime CreatedDate { get; set; }
        Guid DetailKey { get; set; }
        Guid EventDetailKey { get; set; }
        Guid EventKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}