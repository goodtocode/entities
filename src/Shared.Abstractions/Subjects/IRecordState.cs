using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IRecordState
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        int RecordStateId { get; set; }
        Guid RecordStateKey { get; set; }
        string RecordStateName { get; set; }
    }
}