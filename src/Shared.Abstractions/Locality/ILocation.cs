using System;
using System.Collections.Generic;

namespace GoodToCode.Locality.Models
{
    public interface ILocation
    {
        DateTime CreatedDate { get; set; }
        string LocationDescription { get; set; }
        Guid LocationKey { get; set; }
        string LocationName { get; set; }
        DateTime ModifiedDate { get; set; }
        
    }
}