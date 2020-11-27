using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Locality.Models
{
    public interface IAssociateLocation : IDomainEntity<IAssociateLocation>
    {
        Guid AssociateKey { get; set; }
        Guid AssociateLocationKey { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
    }
}