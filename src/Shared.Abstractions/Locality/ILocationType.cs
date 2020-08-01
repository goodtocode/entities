using System;
using System.Collections.Generic;

namespace GoodToCode.Locality.Models
{
    public interface ILocationType
    {
        DateTime CreatedDate { get; set; }
        string LocationTypeDescription { get; set; }
        int LocationTypeId { get; set; }
        Guid LocationTypeKey { get; set; }
        string LocationTypeName { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}