using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventDetail : IDomainModel<IEventDetail>
    {
        Guid DetailKey { get; set; }
        Guid EventDetailKey { get; set; }
        Guid EventKey { get; set; }
    }
}