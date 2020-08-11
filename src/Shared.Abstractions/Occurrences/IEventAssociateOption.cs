using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventAssociateOption
    {
        DateTime CreatedDate { get; set; }
        Guid AssociateKey { get; set; }
        Guid EventAssociateOptionKey { get; set; }
        Guid EventKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
    }
}