using GoodToCode.Shared.Domain;
using System;

namespace GoodToCode.Subjects.Models
{
    public interface IDetail : IDomainModel<IDetail>
    {
        string DetailData { get; set; }
        Guid DetailKey { get; set; }
        Guid DetailTypeKey { get; set; }
        
    }
}