using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventAssociateOption : IDomainEntity<IEventAssociateOption>
    {
        Guid AssociateKey { get; set; }
        Guid EventAssociateOptionKey { get; set; }
        Guid EventKey { get; set; }
        Guid OptionKey { get; set; }
    }
}