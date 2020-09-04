using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Gender : DomainModel<IGender>, IGender
    {
        public override Guid RowKey { get { return GenderKey; } protected set { GenderKey = value; } }
        public Guid GenderKey { get; set; }
        public string GenderName { get; set; }
        public string GenderCode { get; set; }
        
        
    }
}
