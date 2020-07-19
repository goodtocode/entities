using System;
using System.Collections.Generic;

namespace GoodToCode.Entities.Web.Models
{
    public partial class Person
    {
        public Person()
        {
            ResourcePerson = new HashSet<ResourcePerson>();
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

        public virtual Gender Gender { get; set; }
        public virtual Entity PersonKeyNavigation { get; set; }
        public virtual RecordState RecordStateKeyNavigation { get; set; }
        public virtual ICollection<ResourcePerson> ResourcePerson { get; set; }
    }
}
