using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IBusiness: IDomainModel<IBusiness>
    {
        Guid BusinessKey { get; set; }
        string BusinessName { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        
        string TaxNumber { get; set; }
    }
}