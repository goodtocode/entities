using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class OptionGroup : DomainModel<IOptionGroup>, IOptionGroup
    {
        public override Guid RowKey { get { return OptionGroupKey; } set { OptionGroupKey = value; } }
        public Guid OptionGroupKey { get; set; }
        public string OptionGroupName { get; set; }
        public string OptionGroupDescription { get; set; }
        public string OptionGroupCode { get; set; }
    }
}
