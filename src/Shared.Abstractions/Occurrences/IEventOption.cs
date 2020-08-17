using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventOption : IDomainModel<IEventOption>
    {
        Guid EventKey { get; set; }
        Guid EventOptionKey { get; set; }
        Guid OptionKey { get; set; }
    }
}