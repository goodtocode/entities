using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateLocation : DomainModel<IAssociateLocation>, IAssociateLocation
    {
        [Key]
        public Guid AssociateLocationKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }        
        
        
    }
}
