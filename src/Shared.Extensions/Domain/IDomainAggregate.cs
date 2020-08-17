using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Models
{
    public interface IDomainAggregate<TAggregate>
    {
        IReadOnlyList<IDomainEvent<TAggregate>> DomainEvents { get; }
        void ClearDomainEvents();
        bool Equals(object obj);
        int GetHashCode();
    }
}