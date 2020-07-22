using System;

namespace GoodToCode.Shared.Models
{
    public interface IGovernment
    {
        DateTime CreatedDate { get; set; }
        int GovernmentId { get; set; }
        Guid GovernmentKey { get; set; }
        string GovernmentName { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
    }
}