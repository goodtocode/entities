using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public interface IResource
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid RecordStateKey { get; set; }
        string ResourceDescription { get; set; }
        int ResourceId { get; set; }
        Guid ResourceKey { get; set; }
        string ResourceName { get; set; }
    }
}