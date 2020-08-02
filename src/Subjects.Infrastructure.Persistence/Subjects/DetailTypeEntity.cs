using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class DetailTypeEntity : IDetailType
    {
        public DetailTypeEntity()
        {
            Detail = new HashSet<DetailEntity>();
        }

        public int DetailTypeId { get; set; }
        [Key]
        public Guid DetailTypeKey { get; set; }
        public string DetailTypeName { get; set; }
        public string DetailTypeDescription { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<DetailEntity> Detail { get; set; }
    }
}
