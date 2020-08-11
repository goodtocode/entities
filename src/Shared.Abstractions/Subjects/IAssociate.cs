using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociate
    {
        DateTime CreatedDate { get; set; }
        Guid AssociateKey { get; set; }
        DateTime ModifiedDate { get; set; }
    }
}