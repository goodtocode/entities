using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class OptionGroup : IOptionGroup
    {
        [Key]
        public Guid OptionGroupKey { get; set; }
        public string OptionGroupName { get; set; }
        public string OptionGroupDescription { get; set; }
        public string OptionGroupCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
