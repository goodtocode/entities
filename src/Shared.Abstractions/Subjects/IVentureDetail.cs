using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureDetail : IDomainModel<IVentureDetail>
    {
        Guid DetailKey { get; set; }
        Guid VentureDetailKey { get; set; }
        Guid VentureKey { get; set; }
    }
}