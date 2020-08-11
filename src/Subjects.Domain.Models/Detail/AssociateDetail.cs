using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateDetail : IAssociateDetail
    {
        [Key]
        public Guid AssociateDetailKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid DetailKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
