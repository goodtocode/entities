using GoodToCode.Shared.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Gender : DomainModel<IGender>, IGender
    {
        [Key]
        public Guid GenderKey { get; set; }
        public string GenderName { get; set; }
        public string GenderCode { get; set; }
        
        
    }
}
