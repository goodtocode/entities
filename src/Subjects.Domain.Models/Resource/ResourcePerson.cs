using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class ResourcePerson : IResourcePerson
    {
        [Key]
        public Guid ResourcePersonKey { get; set; }
        public Guid ResourceKey { get; set; }
        public Guid PersonKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
