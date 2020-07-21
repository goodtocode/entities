using System;

namespace GoodToCode.Subjects.Models
{
    public interface IEventLocation
    {
        DateTime CreatedDate { get; set; }
        Guid EventKey { get; set; }
        int EventLocationId { get; set; }
        Guid EventLocationKey { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
    }
}