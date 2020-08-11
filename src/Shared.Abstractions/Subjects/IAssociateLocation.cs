using System;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociateLocation
    {
        DateTime CreatedDate { get; set; }
        Guid AssociateKey { get; set; }
        Guid AssociateLocationKey { get; set; }
        Guid LocationKey { get; set; }
        Guid? LocationTypeKey { get; set; }
        DateTime ModifiedDate { get; set; }
        
    }
}