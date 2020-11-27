using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class VentureAssociateOption : DomainEntity<IVentureAssociateOption>, IVentureAssociateOption
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return VentureAssociateOptionKey; } set { VentureAssociateOptionKey = value; } }
        public Guid VentureAssociateOptionKey { get; set; }
        public Guid OptionKey { get; set; }
        public Guid VentureKey { get; set; }
        public Guid AssociateKey { get; set; }
        
        
    }
}
