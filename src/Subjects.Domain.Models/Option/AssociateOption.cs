using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateOption : DomainModel<IAssociateOption>, IAssociateOption
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return AssociateOptionKey; } set { AssociateOptionKey = value; } }
        public Guid AssociateOptionKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid OptionKey { get; set; }
    }
}
