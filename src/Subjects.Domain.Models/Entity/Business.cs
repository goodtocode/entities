using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Business : IBusiness
    {
        [Key]
        public Guid BusinessKey { get; set; }
        public string BusinessName { get; set; }
        public string TaxNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
