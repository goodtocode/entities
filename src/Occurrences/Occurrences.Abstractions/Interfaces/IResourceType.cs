using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IResourceType
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string ResourceTypeDescription { get; set; }
        int ResourceTypeId { get; set; }
        Guid ResourceTypeKey { get; set; }
        string ResourceTypeName { get; set; }
    }
}