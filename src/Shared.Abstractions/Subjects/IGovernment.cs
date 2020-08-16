using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IGovernment : IDomainModel<IGovernment>
    {
        Guid GovernmentKey { get; set; }
        string GovernmentName { get; set; }
    }
}