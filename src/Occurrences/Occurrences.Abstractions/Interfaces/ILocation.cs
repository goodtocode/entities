using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface ILocation
    {
        DateTime CreatedDate { get; set; }
        string LocationDescription { get; set; }
        int LocationId { get; set; }
        Guid LocationKey { get; set; }
        string LocationName { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
    }
}