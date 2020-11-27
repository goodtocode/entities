using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventOption : IDomainEntity<IEventOption>
    {
        Guid EventKey { get; set; }
        Guid EventOptionKey { get; set; }
        Guid OptionKey { get; set; }
    }
}