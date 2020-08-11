using System;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociateDetail
    {
        DateTime CreatedDate { get; set; }
        Guid DetailKey { get; set; }
        Guid AssociateDetailKey { get; set; }
        Guid AssociateKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}