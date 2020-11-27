using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IOptionGroup : IDomainEntity<IOptionGroup>
    {
        string OptionGroupCode { get; set; }
        string OptionGroupDescription { get; set; }
        Guid OptionGroupKey { get; set; }
        string OptionGroupName { get; set; }
    }
}