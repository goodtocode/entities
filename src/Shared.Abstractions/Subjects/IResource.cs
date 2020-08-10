using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IResource
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        
        string ResourceDescription { get; set; }
        Guid ResourceKey { get; set; }
        string ResourceName { get; set; }
    }
}