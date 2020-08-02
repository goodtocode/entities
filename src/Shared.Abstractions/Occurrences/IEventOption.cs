using System;

namespace GoodToCode.Occurrences.Models
{
    public interface IEventOption
    {
        DateTime CreatedDate { get; set; }
        Guid EventKey { get; set; }
        Guid EventOptionKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
    }
}