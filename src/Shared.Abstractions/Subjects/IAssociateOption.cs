using System;

namespace GoodToCode.Subjects.Models
{
    public interface IAssociateOption
    {
        DateTime CreatedDate { get; set; }
        Guid AssociateKey { get; set; }
        Guid AssociateOptionKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
    }
}