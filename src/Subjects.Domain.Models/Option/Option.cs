using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Option : IOption
    {
        [Key]
        public Guid OptionKey { get; set; }
        public Guid OptionGroupKey { get; set; }
        public string OptionName { get; set; }
        public string OptionDescription { get; set; }
        public string OptionCode { get; set; }
        public int SortOrder { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
