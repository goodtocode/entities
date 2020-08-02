using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureEntityOption
    {
        DateTime CreatedDate { get; set; }
        Guid EntityKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
        Guid VentureEntityOptionKey { get; set; }
        Guid VentureKey { get; set; }
    }
}