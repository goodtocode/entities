using System;
using System.Collections.Generic;

namespace GoodToCode.Subjects.Models
{
    public interface IPerson
    {
        DateTime BirthDate { get; set; }
        DateTime CreatedDate { get; set; }
        string FirstName { get; set; }
        string GenderCode { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        DateTime ModifiedDate { get; set; }
        Guid PersonKey { get; set; }
        
    }
}