using GoodToCode.Shared.Models;
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