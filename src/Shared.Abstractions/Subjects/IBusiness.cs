using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IBusiness: IDomainModel<IBusiness>
    {
        Guid BusinessKey { get; set; }
        string BusinessName { get; set; }
        string TaxNumber { get; set; }
    }
}