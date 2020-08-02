using System;

namespace GoodToCode.Subjects.Models
{
    public interface IEntityOption
    {
        DateTime CreatedDate { get; set; }
        Guid EntityKey { get; set; }
        Guid EntityOptionKey { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid OptionKey { get; set; }
    }
}