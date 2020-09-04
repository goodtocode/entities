using GoodToCode.Shared.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace GoodToCode.Subjects.Models
{
    public class Person : DomainModel<IPerson>, IPerson
    {
        public override Guid RowKey { get { return PersonKey; } protected set { PersonKey = value; } }
        public Guid PersonKey { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string GenderCode { get; set; }
        
        
    }
}
