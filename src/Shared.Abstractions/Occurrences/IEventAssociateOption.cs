using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventAssociateOption : IDomainModel<IEventAssociateOption>
    {
        Guid AssociateKey { get; set; }
        Guid EventAssociateOptionKey { get; set; }
        Guid EventKey { get; set; }
        Guid OptionKey { get; set; }
    }
}