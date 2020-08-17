using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureAssociateOption : IDomainModel<IVentureAssociateOption>
    {
        Guid AssociateKey { get; set; }
        Guid OptionKey { get; set; }
        Guid VentureAssociateOptionKey { get; set; }
        Guid VentureKey { get; set; }
    }
}