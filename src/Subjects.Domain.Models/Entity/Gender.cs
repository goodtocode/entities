using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Gender : IGender
    {
        public Gender()
        {
        }

        public int GenderId { get; set; }
        [Key]
        public Guid GenderKey { get; set; }
        public string GenderName { get; set; }
        public string GenderCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
