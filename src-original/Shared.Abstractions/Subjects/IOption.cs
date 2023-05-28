﻿using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IOption : IDomainEntity<IOption>
    {
        string OptionCode { get; set; }
        string OptionDescription { get; set; }
        Guid OptionGroupKey { get; set; }
        Guid OptionKey { get; set; }
        string OptionName { get; set; }
        int SortOrder { get; set; }
    }
}