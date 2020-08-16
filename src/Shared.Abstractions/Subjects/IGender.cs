using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IGender : IDomainModel<IGender>
    {
        string GenderCode { get; set; }
        Guid GenderKey { get; set; }
        string GenderName { get; set; }
    }
}