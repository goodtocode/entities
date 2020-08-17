using GoodToCode.Shared.Models;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IPerson : IDomainModel<IPerson>
    {
        DateTime BirthDate { get; set; }
        string FirstName { get; set; }
        string GenderCode { get; set; }
        string LastName { get; set; }
        string MiddleName { get; set; }
        Guid PersonKey { get; set; }
    }
}