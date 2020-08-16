using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateDetail : DomainModel<IAssociateDetail>, IAssociateDetail
    {
        [Key]
        public Guid AssociateDetailKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid DetailKey { get; set; }
        
        
    }
}
