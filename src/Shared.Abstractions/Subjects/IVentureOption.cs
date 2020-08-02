using System;

namespace GoodToCode.Subjects.Models
{
    public interface IVentureOption
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
        Guid VentureKey { get; set; }
        Guid VentureOptionKey { get; set; }
    }
}