using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventEntityOption
    {
        DateTime CreatedDate { get; set; }
        Guid EntityKey { get; set; }
        Guid EventEntityOptionKey { get; set; }
        Guid EventKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
    }
}