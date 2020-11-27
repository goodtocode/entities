using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociateOption : IDomainEntity<IAssociateOption>
    {
        Guid AssociateKey { get; set; }
        Guid AssociateOptionKey { get; set; }
        Guid OptionKey { get; set; }
    }
}