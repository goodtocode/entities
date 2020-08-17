using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Locality.Models
{
    public interface ILocation : IDomainModel<ILocation>
    {
        
        string LocationDescription { get; set; }
        Guid LocationKey { get; set; }
        string LocationName { get; set; }
        
        
    }
}