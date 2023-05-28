using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IDetail : IDomainEntity<IDetail>
    {
        string DetailData { get; set; }
        Guid DetailKey { get; set; }
        Guid DetailTypeKey { get; set; }
        
    }
}