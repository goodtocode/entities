using GoodToCode.Shared.Models;
using System;
using System.Collections.Generic;

namespace GoodToCode.Locality.Models
{
    public interface ILocationType : IDomainModel<ILocationType>
    {        
        string LocationTypeDescription { get; set; }
        Guid LocationTypeKey { get; set; }
        string LocationTypeName { get; set; }
        
    }
}