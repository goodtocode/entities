using System;

namespace GoodToCode.Locality.Models
{
    public interface ILocationArea
    {
        Guid AreaKey { get; set; }
        DateTime CreatedDate { get; set; }
        Guid LocationAreaKey { get; set; }
        Guid LocationKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}