using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IDetail
    {
        DateTime CreatedDate { get; set; }
        string DetailData { get; set; }
        Guid DetailKey { get; set; }
        Guid DetailTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}