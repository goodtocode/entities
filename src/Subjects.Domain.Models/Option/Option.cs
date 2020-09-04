using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Option : DomainModel<IOption>, IOption
    {
        public override Guid RowKey { get { return OptionKey; } protected set { OptionKey = value; } }
        public Guid OptionKey { get; set; }
        public Guid OptionGroupKey { get; set; }
        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
        public string OptionCode { get; set; }
        public int SortOrder { get; set; }
    }
}
