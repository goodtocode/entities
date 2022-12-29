using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Locality.Models
{
    public class AssociateLocation : DomainEntity<IAssociateLocation>, IAssociateLocation
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return AssociateLocationKey; } set { AssociateLocationKey = value; } }
        public Guid AssociateLocationKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }
    }
}
