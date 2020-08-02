using System;

namespace GoodToCode.Subjects.Models
{
    public interface IGovernment
    {
        DateTime CreatedDate { get; set; }
        Guid GovernmentKey { get; set; }
        string GovernmentName { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
    }
}