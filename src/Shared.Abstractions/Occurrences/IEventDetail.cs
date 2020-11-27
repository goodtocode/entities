using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventDetail : IDomainEntity<IEventDetail>
    {
        Guid DetailKey { get; set; }
        Guid EventDetailKey { get; set; }
        Guid EventKey { get; set; }
    }
}