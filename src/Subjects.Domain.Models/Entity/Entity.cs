using System;

namespace GoodToCode.Subjects.Models
{
    public class Entity : IEntity
    {
        public Entity()
        {
        }

        public int EntityId { get; set; }
        public Guid EntityKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
