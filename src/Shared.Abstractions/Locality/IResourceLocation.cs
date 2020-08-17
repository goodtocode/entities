using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Locality.Models
{
    public interface IResourceLocation : IDomainModel<IResourceLocation>
    {
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid ResourceLocationKey { get; set; }
    }
}