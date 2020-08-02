
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Resource : IResource
    {
        public Resource()
        {
        }

        public int ResourceId { get; set; }
        [Key]
        public Guid ResourceKey { get; set; }
        public string ResourceName { get; set; }
        public string ResourceDescription { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
