using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureAssociateOption : IDomainEntity<IVentureAssociateOption>
    {
        Guid AssociateKey { get; set; }
        Guid OptionKey { get; set; }
        Guid VentureAssociateOptionKey { get; set; }
        Guid VentureKey { get; set; }
    }
}