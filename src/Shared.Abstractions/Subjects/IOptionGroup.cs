using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IOptionGroup : IDomainModel<IOptionGroup>
    {
        string OptionGroupCode { get; set; }
        string OptionGroupDescription { get; set; }
        Guid OptionGroupKey { get; set; }
        string OptionGroupName { get; set; }
    }
}