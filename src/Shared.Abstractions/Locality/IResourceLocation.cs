using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Locality.Models
{
    public interface IResourceLocation : IDomainEntity<IResourceLocation>
    {
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid ResourceLocationKey { get; set; }
    }
}