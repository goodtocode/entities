using Goodtocode.Common.Domain;

namespace Goodtocode.Common.Domain;

public interface IDomainEntity<TModel> where TModel : IDomainObject
{
    Guid RowKey { get; }
    string PartitionKey { get; }
    void RaiseDomainEvent(IDomainEvent<TModel> domainEvent);
    void ClearDomainEvents();
    bool Equals(object obj);
    int GetHashCode();
}