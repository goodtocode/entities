using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Locality.Models
{
    public interface ILocationArea : IDomainModel<ILocationArea>
    {
        Guid AreaKey { get; set; }
        
        Guid LocationAreaKey { get; set; }
        Guid LocationKey { get; set; }
        
    }
}