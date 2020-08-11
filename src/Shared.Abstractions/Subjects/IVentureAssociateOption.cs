using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureAssociateOption
    {
        DateTime CreatedDate { get; set; }
        Guid AssociateKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
        Guid VentureAssociateOptionKey { get; set; }
        Guid VentureKey { get; set; }
    }
}