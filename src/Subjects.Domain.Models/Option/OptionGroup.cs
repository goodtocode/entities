using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class OptionGroup : DomainModel<IOptionGroup>, IOptionGroup
    {
        [Key]
        public Guid OptionGroupKey { get; set; }
        public string OptionGroupName { get; set; }
        public string OptionGroupDescription { get; set; }
        public string OptionGroupCode { get; set; }
    }
}
