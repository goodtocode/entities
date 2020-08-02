using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IOption
    {
        DateTime CreatedDate { get; set; }
        DateTime ModifiedDate { get; set; }
        string OptionCode { get; set; }
        string OptionDescription { get; set; }
        Guid OptionGroupKey { get; set; }
        Guid OptionKey { get; set; }
        string OptionName { get; set; }
        int SortOrder { get; set; }
    }
}