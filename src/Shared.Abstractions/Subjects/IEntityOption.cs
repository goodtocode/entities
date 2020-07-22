using System;

namespace GoodToCode.Shared.Models
{
    public interface IEntityOption
    {
        DateTime CreatedDate { get; set; }
        Guid EntityKey { get; set; }
        int EntityOptionId { get; set; }
        Guid EntityOptionKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
    }
}