using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class EntityDetail : IEntityDetail
    {
        [Key]
        public int EntityDetailId { get; set; }
        public Guid EntityDetailKey { get; set; }
        public Guid EntityKey { get; set; }
        public Guid DetailKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
