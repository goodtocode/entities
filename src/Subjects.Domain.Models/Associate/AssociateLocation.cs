using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class AssociateLocation : IAssociateLocation
    {
        [Key]
        public Guid AssociateLocationKey { get; set; }
        public Guid AssociateKey { get; set; }
        public Guid LocationKey { get; set; }
        public Guid? LocationTypeKey { get; set; }        
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
