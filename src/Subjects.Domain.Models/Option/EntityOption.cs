using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class EntityOption : IEntityOption
    {
        [Key]
        public int EntityOptionId { get; set; }
        public Guid EntityOptionKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid OptionKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
