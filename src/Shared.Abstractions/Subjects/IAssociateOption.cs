using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociateOption : IDomainModel<IAssociateOption>
    {
        Guid AssociateKey { get; set; }
        Guid AssociateOptionKey { get; set; }
        Guid OptionKey { get; set; }
    }
}