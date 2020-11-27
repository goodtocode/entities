using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventResource : IDomainEntity<IEventResource>
    {
        Guid EventKey { get; set; }
        Guid EventResourceKey { get; set; }
        Guid ResourceKey { get; set; }
        Guid? ResourceTypeKey { get; set; }
    }
}