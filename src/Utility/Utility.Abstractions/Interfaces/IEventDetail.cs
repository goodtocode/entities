using System;

namespace GoodToCode.Subjects.Models
{
    public interface IEventDetail
    {
        DateTime CreatedDate { get; set; }
        Guid DetailKey { get; set; }
        int EventDetailId { get; set; }
        Guid EventDetailKey { get; set; }
        Guid EventKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}