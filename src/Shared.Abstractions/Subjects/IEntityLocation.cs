using System;

namespace GoodToCode.Subjects.Models
{
    public interface IEntityLocation
    {
        DateTime CreatedDate { get; set; }
        Guid EntityKey { get; set; }
        Guid EntityLocationKey { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
    }
}