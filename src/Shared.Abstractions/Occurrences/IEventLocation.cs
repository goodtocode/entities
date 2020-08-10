using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventLocation
    {
        DateTime CreatedDate { get; set; }
        Guid EventKey { get; set; }
        Guid EventLocationKey { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
    }
}