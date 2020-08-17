using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventResource : IDomainModel<IEventResource>
    {
        Guid EventKey { get; set; }
        Guid EventResourceKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid? ResourceTypeKey { get; set; }
    }
}