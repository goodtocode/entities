using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociateDetail : IDomainEntity<IAssociateDetail>
    {
        Guid DetailKey { get; set; }
        Guid AssociateDetailKey { get; set; }
        Guid AssociateKey { get; set; }
    }
}