using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Locality.Models
{
    public interface IArea : IDomainModel<IArea>
    {
        Guid AreaKey { get; set; }
        
    }
}