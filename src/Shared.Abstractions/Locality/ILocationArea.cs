using System;

namespace GoodToCode.Shared.Models
{
    public interface ILocationArea
    {
        Guid AreaKey { get; set; }
        DateTime CreatedDate { get; set; }
        int LocationAreaId { get; set; }
        Guid LocationAreaKey { get; set; }
        Guid LocationKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}