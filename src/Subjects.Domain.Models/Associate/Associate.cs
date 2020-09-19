using GoodToCode.Shared.Models;
using GoodToCode.Shared.Extensions;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Associate : DomainModel<IAssociate>, IAssociate
    {
        public override Guid RowKey { get { return AssociateKey; } set { AssociateKey = value; } }
        public Guid AssociateKey { get; set; }                
    }
}
