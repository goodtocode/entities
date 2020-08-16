using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateOption : DomainModel<IAssociateOption>, IAssociateOption
    {
        [Key]
        public Guid AssociateOptionKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid OptionKey { get; set; }
    }
}
