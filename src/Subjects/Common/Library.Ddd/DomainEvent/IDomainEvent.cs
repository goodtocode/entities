namespace Goodtocode.Library.Ddd;

public interface IDomainEvent<T> where T : IDomainObject
{
    T Item { get; }
}