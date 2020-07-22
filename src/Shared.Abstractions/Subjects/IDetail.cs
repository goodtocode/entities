using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public interface IDetail
    {
        DateTime CreatedDate { get; set; }
        string DetailData { get; set; }
        int DetailId { get; set; }
        Guid DetailKey { get; set; }
        Guid DetailTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}