using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IDetailType
    {
        DateTime CreatedDate { get; set; }
        string DetailTypeDescription { get; set; }
        Guid DetailTypeKey { get; set; }
        string DetailTypeName { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}