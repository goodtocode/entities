using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IEntity
    {
        DateTime CreatedDate { get; set; }
        Guid EntityKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}