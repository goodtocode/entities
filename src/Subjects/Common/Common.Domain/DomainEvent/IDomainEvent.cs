namespace Goodtocode.Common.Domain;

public interface IDomainEvent<T> where T : IDomainObject
{
    T Item { get; }
}