using System;

namespace GoodToCode.Shared.Models
{
    public interface IEntityLocation
    {
        DateTime CreatedDate { get; set; }
        Guid EntityKey { get; set; }
        int EntityLocationId { get; set; }
        Guid EntityLocationKey { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
    }
}