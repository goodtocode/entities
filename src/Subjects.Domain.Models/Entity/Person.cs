using System;

namespace GoodToCode.Subjects.Models
{
    public class Person : IPerson
    {
        public Person()
        {
        }

        public int PersonId { get; set; }
        public Guid PersonKey { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public int GenderId { get; set; }
        public Guid RecordStateKey { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
    }
}
