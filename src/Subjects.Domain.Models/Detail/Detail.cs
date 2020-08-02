using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Detail : IDetail
    {
        public Detail()
        {
        }

        public int DetailId { get; set; }
        [Key]
        public Guid DetailKey { get; set; }
        public Guid DetailTypeKey { get; set; }
        public string DetailData { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
