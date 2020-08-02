using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Entity : IEntity
    {
        public Entity()
        {
        }

        public int EntityId { get; set; }
        [Key]
        public Guid EntityKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
