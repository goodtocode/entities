using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureOption : IDomainEntity<IVentureOption>
    {
        Guid OptionKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureOptionKey { get; set; }
    }
}