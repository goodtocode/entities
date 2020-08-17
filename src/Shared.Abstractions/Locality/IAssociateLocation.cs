using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Locality.Models
{
    public interface IAssociateLocation : IDomainModel<IAssociateLocation>
    {
        Guid AssociateKey { get; set; }
        Guid AssociateLocationKey { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
    }
}