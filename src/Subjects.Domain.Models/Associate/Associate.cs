using GoodToCode.Shared.Domain;
using GoodToCode.Shared.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Associate : DomainModel<Associate>, IAssociate
    {
        [Key]
        public Guid AssociateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
