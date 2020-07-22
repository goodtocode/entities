using System;

namespace GoodToCode.Shared.Models
{
    public interface IVentureOption
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
        Guid VentureKey { get; set; }
        int VentureOptionId { get; set; }
        Guid VentureOptionKey { get; set; }
    }
}