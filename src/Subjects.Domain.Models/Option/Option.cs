using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Option : DomainEntity<IOption>, IOption
    {
        public override string PartitionKey { get; set; } = "Default";
        public override Guid RowKey { get { return OptionKey; } set { OptionKey = value; } }
        public Guid OptionKey { get; set; }
        public Guid OptionGroupKey { get; set; }
        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
        public string OptionCode { get; set; }
        public int SortOrder { get; set; }
    }
}
