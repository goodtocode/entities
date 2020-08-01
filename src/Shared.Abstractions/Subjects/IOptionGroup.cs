using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IOptionGroup
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string OptionGroupCode { get; set; }
        string OptionGroupDescription { get; set; }
        int OptionGroupId { get; set; }
        Guid OptionGroupKey { get; set; }
        string OptionGroupName { get; set; }
    }
}