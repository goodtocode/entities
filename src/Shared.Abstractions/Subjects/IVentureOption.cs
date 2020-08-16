using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureOption : IDomainModel<IVentureOption>
    {
        Guid OptionKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureOptionKey { get; set; }
    }
}