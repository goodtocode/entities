using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IOption : IDomainModel<IOption>
    {
        string OptionCode { get; set; }
        string OptionDescription { get; set; }
        Guid OptionGroupKey { get; set; }
        Guid OptionKey { get; set; }
        string OptionName { get; set; }
        int SortOrder { get; set; }
    }
}