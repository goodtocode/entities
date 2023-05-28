using Goodtocode.Library.Ddd;

namespace Goodtocode.Library.Ddd;

public interface IDomainEntity<TModel> where TModel : IDomainObject
{
    Guid RowKey { get; }
    string PartitionKey { get; }
    void RaiseDomainEvent(IDomainEvent<TModel> domainEvent);
    void ClearDomainEvents();
    bool Equals(object obj);
    int GetHashCode();
}