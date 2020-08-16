using GoodToCode.Shared.Domain;
using GoodToCode.Shared.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Associate : DomainModel<IAssociate>, IAssociate
    {
        [Key]
        public Guid AssociateKey { get; set; }
        
        
    }
}
