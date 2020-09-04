using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateDetail : DomainModel<IAssociateDetail>, IAssociateDetail
    {
        public override Guid RowKey { get { return AssociateDetailKey; } protected set { AssociateDetailKey = value; } }
        public Guid AssociateDetailKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid DetailKey { get; set; }
        
        
    }
}
