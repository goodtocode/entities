using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateOption : IAssociateOption
    {
        [Key]
        public Guid AssociateOptionKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid OptionKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
