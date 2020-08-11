using System;
using System.Collections.Generic;

namespace GoodToCode.Shared.Domain
{
    public interface IDomainAggregate<TAggregate>
    {
        IReadOnlyList<IDomainEvent<TAggregate>> DomainEvents { get; }
        void ClearDomainEvents();
        bool Equals(object obj);
        int GetHashCode();
    }
}