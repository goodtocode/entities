using System;

namespace GoodToCode.Subjects.Models
{
    public interface IBusiness
    {
        int BusinessId { get; set; }
        Guid BusinessKey { get; set; }
        string BusinessName { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        string TaxNumber { get; set; }
    }
}