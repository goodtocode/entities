using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class EntityOption : IEntityOption
    {
        public int EntityOptionId { get; set; }
        [Key]
        public Guid EntityOptionKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid OptionKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
