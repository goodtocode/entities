using GoodToCode.Shared.Domain;
using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociate : IDomainModel<IAssociate>
    {
        Guid AssociateKey { get; set; }
    }
}